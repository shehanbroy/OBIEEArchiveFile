'##=====================================================================
'## Title: Export Report
'## Rev: 1.0
'## Author: Swaminathan Vadivelu
'## Purpose:
'## 1. This script takes a file from OBIEE and saves to the file system
'## 2. Creates a reporting subdirectory if not already present
'##
'## Inputs (specified in Actions tab of OBIEE Delivers Agent):
'## 1. Parameter(0) - This actual file to be exported
'## 2. Parameter(1) - The file name specified within OBIEE
'##
'##=====================================================================

'##Create a variable and assign the base folder path where to store the file:
Dim sPath
sPath = "D:\Report Exports"
'##Remember the above path is either a shared folder or folder on OBIEE server.

Dim objFSO
Set objFSO = CreateObject("Scripting.FileSystemObject")

'##check whether directory exists, if not create
Dim objDir
If Not objFSO.FolderExists(sPath) Then
Set objDir = objFSO.CreateFolder(sPath)
End If
Set objDir = Nothing

'##build string to get date in yyyy-mm-dd format
Dim sDate, sDateFull
sDate = Now
sDateFull = DatePart("yyyy", sDate) & "-"
If Len(DatePart("m", sDate))=1 Then sDateFull = sDateFull & "0" End If
sDateFull = sDateFull & DatePart("m", sDate) & "-"
If Len(DatePart("d", sDate))=1 Then sDateFull = sDateFull & "0" End If
sDateFull = sDateFull & DatePart("d", sDate)

'##Create a complete path with file name and add the date on the file name:
Dim sFileName
sFileName = sPath & "\" & Parameter(1) & "-" & sDateFull & ".xls"

'##Place the file on the folder:
Dim objFile
objFSO.CopyFile Parameter(0), sFileName, True
Set objFile = Nothing
Set objFSO = Nothing