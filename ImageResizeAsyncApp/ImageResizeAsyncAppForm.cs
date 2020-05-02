using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace ImageResizeAsyncApp
{
    public partial class ImageResizeAsyncAppForm : Form
    {
        public ImageResizeAsyncAppForm()
        {
            InitializeComponent();
        }

        
        // アプリを起動したときの処理
        private void ImageResizeAppForm_Load(object sender, EventArgs e)
        {
            // テキストボックスに初期値を設定
            folderInputTextbox.Text = @"";
            // キャレットの位置を指定
            folderInputTextbox.SelectionStart = folderInputTextbox.Text.Length;
            // キャンセルボタンを無効化
            cancelButton.Enabled = false;
        }

        
        // フォルダ選択ボタンを押したときの処理
        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            var dr = folderSelectDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                folderInputTextbox.Text = folderSelectDialog.SelectedPath;
            }
        }

        
        // ドラッグ時の処理
        private void ResizeDrag(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        
        // キャンセル用トークンを作成するためのインスタンス変数を定義
        private CancellationTokenSource _cancelToken;
        
        // ドロップ時の処理
        private async void ResizeDrop(object sender, DragEventArgs e)
        {
            // ドロップエリアを無効化
            resizeDropArea.Enabled = false;        
            
            // キャンセルボタンを有効化
            cancelButton.Enabled = true;
            
            // キャンセル用トークンを作成
            _cancelToken = new CancellationTokenSource();
            
            // ドロップされたフォルダのパスの配列を取得
            var folderPathArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            // ZIPファイルを保存する場所を指定
            var saveFolderPath = folderInputTextbox.Text;

            // 処理するフォルダの総数を取得
            var maxFolderCount = folderPathArray.Length;

            // ラジオボタンの状態によってリサイズ画像の高さの値を設定
            var resizeHeight = 900;
            if (radioButton1200pixels.Checked)
            {
                 resizeHeight = 1200;
            }
            
            // プログレスバーの初期設定
            progressBar.Minimum = 0;
            progressBar.Maximum = maxFolderCount;
            progressBar.Value = 0;
            // プログレスバーの状況を表示するラベルの初期値を設定
            progressDisplayLabel.Text = $@"{maxFolderCount}個中0個のフォルダを処理しました";
            progressDisplayLabel.Update();

            // 処理済みのフォルダ数を定義しておく
            var folderCount = 1;
            
            try
            {
                // 各フォルダに対する処理
                foreach (var folderPath in folderPathArray)
                {
                    try
                    {                    
                        // 非同期処理でリサイズ圧縮処理
                        var folderPathObject = new FolderPathClass(folderPath);  
                        await Task.Run(() => folderPathObject.ImageResizeZipMethod(resizeHeight, saveFolderPath, _cancelToken));                       
                        
                        // プログレスバーの更新
                        progressBar.Value = folderCount;                       
                        
                        // プログレスバーの状況を表示するラベルの値を更新
                        progressDisplayLabel.Text = $@"{maxFolderCount}個中{folderCount}個のフォルダを処理しました";
                        progressDisplayLabel.Update();
                        
                        // 処理済みのフォルダ数を+1する
                        folderCount++;
                    }
                    // キャンセルボタンが押された場合の処理                      
                    catch (AggregateException)
                    {
                        // temporaryFolderを削除
                        FileSystem.DeleteDirectory(@".\temporaryFolder",
                                                   UIOption.OnlyErrorDialogs,
                                                   RecycleOption.DeletePermanently);
    
                        // ZIPファイルのパスを作成
                        var folderName = Path.GetFileName(folderPath);
                        var zipFileName = folderName + ".zip";
                        var zipFilePath = Path.Combine(saveFolderPath, zipFileName);
    
                        // ZIPファイルを作成していたら削除
                        if (File.Exists(zipFilePath))
                        {
                            FileSystem.DeleteFile(zipFilePath);
                        }                                             
                    }     
                    // 上記以外のエラーが発生した時の処理
                    catch (Exception ex)
                    {
                        // temporaryFolderを削除
                        FileSystem.DeleteDirectory(@".\temporaryFolder",
                                                   UIOption.OnlyErrorDialogs,
                                                   RecycleOption.DeletePermanently);
    
                        // ZIPファイルのパスを作成
                        var folderName = Path.GetFileName(folderPath);
                        var zipFileName = folderName + ".zip";
                        var zipFilePath = Path.Combine(saveFolderPath, zipFileName);
    
                        // ZIPファイルを作成していたら削除
                        if (File.Exists(zipFilePath))
                        {
                            FileSystem.DeleteFile(zipFilePath);
                        }
                        
                        // エラーメッセージを表示
                        MessageBox.Show(ex.Message,
                                        $@"{folderName}の処理中にエラーが発生しました",
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
    
                        // プログレスバーの更新
                        progressBar.Value = folderCount;
                        
                        // プログレスバーの状況を表示するラベルの値を更新
                        progressDisplayLabel.Text = $@"{maxFolderCount}個中{folderCount}個のフォルダを処理しました";
                        progressDisplayLabel.Update();
                        
                        // 処理済みのフォルダ数を+1する
                        folderCount++;
                    }
                    // キャンセル命令の有無を確認
                    _cancelToken.Token.ThrowIfCancellationRequested();                   
                }
                // プログレスバーの状況を表示するラベルに完了を表示
                progressDisplayLabel.Text = @"処理が完了しました";
                progressDisplayLabel.Update();
                // 完了音を鳴らす
                var completeSound = new SoundPlayer(@"Alarm03.wav");
                completeSound.Play();
                
                // ドロップエリアを有効化
                resizeDropArea.Enabled = true;
                // キャンセルボタンを無効化
                cancelButton.Enabled = false;
            }
            catch (OperationCanceledException)
            {
                // エラーメッセージを表示
                MessageBox.Show("処理をキャンセルしました",
                                "処理を中断しました",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                
                // プログレスバーの状況を表示するラベルにキャンセルを表示
                progressDisplayLabel.Text = @"処理をキャンセルしました";
                progressDisplayLabel.Update();
             
                // ドロップエリアを有効化
                resizeDropArea.Enabled = true;
                // キャンセルボタンを無効化
                cancelButton.Enabled = false;
            } 
        }

        
        // キャンセルボタンを押したときの処理
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if(_cancelToken != null)
            {
                _cancelToken.Cancel();
            }
        }
    }
}
