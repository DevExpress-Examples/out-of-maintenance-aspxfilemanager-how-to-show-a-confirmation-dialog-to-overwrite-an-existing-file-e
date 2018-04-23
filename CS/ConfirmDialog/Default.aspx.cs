using DevExpress.Web.ASPxFileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfirmDialog
{
    public partial class Default : System.Web.UI.Page
    {
        MyCustomProviderOptions ProviderOptions { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            FileManager.CustomFileSystemProvider = CreateCustomFileSystemProvider();
        }

        private FileSystemProviderBase CreateCustomFileSystemProvider()
        {
            ProviderOptions = new MyCustomProviderOptions();
            MyCustomFileSystemProvider provider = new MyCustomFileSystemProvider(FileManager.Settings.RootFolder, ProviderOptions);

            return provider;
        }

        protected void ASPxFileManager1_FileUploading(object source, FileManagerFileUploadEventArgs e)
        {
            ProviderOptions.AllowOverwrite = Convert.ToBoolean(HiddenField["overwrite"]);
        }
    }

    public class MyCustomFileSystemProvider : PhysicalFileSystemProvider
    {
        MyCustomProviderOptions ProviderOptions { get; set; }

        public MyCustomFileSystemProvider(string rootFolder, MyCustomProviderOptions providerOptions)
            : base(rootFolder)
        {
            ProviderOptions = providerOptions;
        }
        public override bool Exists(FileManagerFile file)
        {
            if (ProviderOptions.AllowOverwrite)
                return false;
            return base.Exists(file);
        }
        public override void UploadFile(FileManagerFolder folder, string fileName, System.IO.Stream content)
        {
            base.UploadFile(folder, fileName, content);
            ProviderOptions.AllowOverwrite = false;
        }
    }

    public class MyCustomProviderOptions
    {
        public bool AllowOverwrite { get; set; }
    }
}