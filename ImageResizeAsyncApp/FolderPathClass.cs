using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using System.Threading;

namespace ImageResizeAsyncApp
{
    // クラスの定義
    class FolderPathClass
    {
        // インスタンス変数の定義
        public string FolderPath;

        // インスタンス変数の初期化
        public FolderPathClass(string folderPath)
        {
            FolderPath = folderPath;
        }
        
        // メソッドの定義
        public void ImageResizeZipMethod(int resizeHeight, string saveFolderPath, CancellationTokenSource cancelToken)
        {
            // 一時フォルダがなければ作成する
            if (!Directory.Exists(@".\temporaryFolder"))
            {
                FileSystem.CreateDirectory(@".\temporaryFolder");
            }
            
            // ZIPファイルのパスを作成
            var folderName = Path.GetFileName(FolderPath);
            var zipFileName = folderName + ".zip";
            var zipFilePath = Path.Combine(saveFolderPath, zipFileName);
            
            // フォルダ内のすべてのファイルのパスを取得
            var filePathArray = Directory.GetFiles(FolderPath, "*");
            
            // Parallel.ForEach文で実行するサブスレッドの数を指定
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 3;
            
            // lock構文を使用する際に必要になる引数
            var lockObj = new object();

            // 各ファイルに対する処理を非同期で行う
            Parallel.ForEach(filePathArray, options, filePath =>
            {
                // ファイルが画像ファイルのときの処理
                if (filePath.Contains(".jpg") || filePath.Contains(".JPG") ||
                    filePath.Contains(".jpeg") || filePath.Contains(".JPEG") ||
                    filePath.Contains(".png") || filePath.Contains(".PNG") ||
                    filePath.Contains(".gif") || filePath.Contains(".GIF"))
                {
                    // リサイズ画像のパスを作成
                    var outputFolderPath = @".\temporaryFolder";
                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    var resizeFileExtensionName = ".jpg";
                    var resizeFileName = fileName + resizeFileExtensionName;
                    var resizeFilePath = Path.Combine(outputFolderPath, resizeFileName);
    
                    // リサイズ画像を作成
                    using (var sourceImage = new Bitmap(filePath))
                    {
                        // 幅のリサイズ値を取得
                        var resizeWidth = (sourceImage.Width * resizeHeight) / sourceImage.Height;

                        // 元画像の高さがリサイズ値よりも大きかった場合(リサイズする必要がある場合)
                        if (sourceImage.Height > resizeHeight)
                        {
                            using (var resizeImage = new Bitmap(resizeWidth, resizeHeight))
                            {
                                using (var graphic = Graphics.FromImage(resizeImage))
                                {
                                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                    graphic.DrawImage(sourceImage, 0, 0, resizeWidth, resizeHeight);
                                    resizeImage.Save(resizeFilePath, ImageFormat.Jpeg);
                                }  
                            }
                        }
                        // 元画像の高さがリサイズ値以下だった場合(リサイズする必要がない場合)
                        else if (sourceImage.Height <= resizeHeight)
                        {
                            // リサイズせずに画像形式だけ変換する
                            sourceImage.Save(resizeFilePath, ImageFormat.Jpeg);
                        }
                    }
                    
                    // リサイズ画像をZIPファイルに追加
                    lock (lockObj)
                    {
                        using (var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
                        {
                            zipArchive.CreateEntryFromFile(resizeFilePath, 
                                                           Path.GetFileName(resizeFilePath),
                                                           CompressionLevel.Optimal);
                        }
                    }

                    // リサイズ画像を削除
                    FileSystem.DeleteFile(resizeFilePath);
                }
                // キャンセル命令の有無を確認
                cancelToken.Token.ThrowIfCancellationRequested();
            });

            // フォルダを削除(ゴミ箱へ移動)
            FileSystem.DeleteDirectory(FolderPath,
                                       UIOption.OnlyErrorDialogs,
                                       RecycleOption.SendToRecycleBin);
        }
    }
}
