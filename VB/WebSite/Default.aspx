<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to show a confirmation dialog to overwrite an existing file</title>
	<script type="text/javascript">
		function uploadStarted(s, e) {
			var fileNames = e.fileName.split(", ");
			var existsFiles = fileManager.GetItems();

			var founded = [];

			for (var i = 0; i < existsFiles.length; i++) {
				var ef = existsFiles[i];
				for (var j = 0; j < fileNames.length; j++) {
					if (ef.name.toLowerCase() == fileNames[j].toLowerCase())
						founded.push(ef.name);
				}
			}
			if (founded.length > 0) {
				if (confirm(founded.length + " file(s) with the same name exist(s). Are you sure you want to overwrite?")) {
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
	<div>
		<dx:ASPxHiddenField ID="ASPxHiddenField1" ClientInstanceName="hiddenField" runat="server">
		</dx:ASPxHiddenField>
		<dx:ASPxFileManager ID="ASPxFileManager1" ClientInstanceName="fileManager" runat="server"
			OnFileUploading="ASPxFileManager1_FileUploading">
			<ClientSideEvents FileUploading="uploadStarted"></ClientSideEvents>
			<Settings RootFolder="~\" ThumbnailFolder="~\Thumb\" />
			<SettingsUpload AdvancedModeSettings-EnableMultiSelect="true">
			</SettingsUpload>
		</dx:ASPxFileManager>
	</div>
	</form>
</body>
</html>