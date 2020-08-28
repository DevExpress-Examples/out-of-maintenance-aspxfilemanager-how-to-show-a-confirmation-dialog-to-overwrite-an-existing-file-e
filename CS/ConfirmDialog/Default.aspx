<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConfirmDialog.Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function uploadStarted(s, e) {
            var fileNames = e.fileName.split(", ");
            var existsFiles = fileManager.GetItems();

            var found = [];

            for (var i = 0; i < existsFiles.length; i++) {
                var ef = existsFiles[i];
                for (var j = 0; j < fileNames.length; j++) {
                    if (ef.name.toLowerCase() == fileNames[j].toLowerCase())
                        found.push(ef.name);
                }
            }
            if (found.length > 0) {
                if (confirm(found.length + " file(s) with the same name exist(s). Are you sure you want to overwrite?")) {
                    hiddenField.Set("overwrite", true);
                    return
                }
                e.cancel = true;
            }
            hiddenField.Set("overwrite", false);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxHiddenField ID="HiddenField" ClientInstanceName="hiddenField" runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxFileManager ID="FileManager" ClientInstanceName="fileManager" runat="server"
            OnFileUploading="ASPxFileManager1_FileUploading">
            <ClientSideEvents FileUploading="uploadStarted"></ClientSideEvents>
            <Settings RootFolder="~\FileSystem" ThumbnailFolder="~\Thumb\" />
            <SettingsUpload AdvancedModeSettings-EnableMultiSelect="true">
            </SettingsUpload>
        </dx:ASPxFileManager>
    </form>
</body>
</html>
