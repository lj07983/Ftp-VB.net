Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ftpclient As System.Net.FtpWebRequest = System.Net.FtpWebRequest.Create(New System.Uri("ftp://183.136.203.146/软件"))
        ftpclient.UseBinary = True
        ftpclient.Credentials = New System.Net.NetworkCredential("upload", "upload")
        ftpclient.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails

        ftpclient.KeepAlive = False

        Dim ftpresponse As System.Net.FtpWebResponse = CType(ftpclient.GetResponse, System.Net.FtpWebResponse)

        Console.WriteLine(ftpresponse.StatusCode.ToString + " " + ftpresponse.StatusDescription)

        Dim content(1024) As Byte
        Dim index_a As Integer = 0
        index_a = ftpresponse.GetResponseStream.Read(content, 0, content.Length)
        Dim contentstring As String = String.Empty
        While index_a > 0
            index_a = ftpresponse.GetResponseStream.Read(content, 0, content.Length)
            contentstring += System.Text.Encoding.UTF8.GetString(content)
        End While



        ftpresponse.Close()

        If contentstring.LastIndexOf("aaa.txt") > 0 Then
            MsgBox("存在")
        Else
            MsgBox("不存在")
        End If

    End Sub
End Class
