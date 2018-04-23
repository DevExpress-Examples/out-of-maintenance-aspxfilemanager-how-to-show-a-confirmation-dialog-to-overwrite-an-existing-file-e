using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void ASPxFileManager1_FileUploading(object source, DevExpress.Web.ASPxFileManager.FileManagerFileUploadEventArgs e)
    {
            //Comment these lines to upload the file************************
            e.Cancel = true;
            throw new Exception("upload is not allowed in online examples ");
            //**************************************************************

            if (Convert.ToBoolean(ASPxHiddenField1["overwrite"]))
            {
                var existFile = ASPxFileManager1.SelectedFolder.GetFiles().FirstOrDefault(f => f.Name.Equals(e.FileName, StringComparison.InvariantCultureIgnoreCase));
                if (existFile != null)
                    File.Delete(Path.Combine(MapPath("~"), existFile.RelativeName)); // A path depends on the RootFolder in the file manager
            }
     
    }

}