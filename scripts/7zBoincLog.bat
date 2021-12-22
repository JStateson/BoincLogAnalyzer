rem removed echos to allow other users to build in their own environment (no D drive)
rem but they need 7z in program files
set SRC=%2
set ARC=%1\BoincLogExe.7z
set IS_64=%Src:~-12,-9%
rem "C:\Program Files\7-Zip\7z.exe -u"
rem echo %IS_64% >>  D:\Projects\VSrepository\BLAresults.txt
if %IS_64% == x64 (
rem echo %2%364.exe >>  D:\Projects\VSrepository\BLAresults.txt
set PGM=%2%364.exe
) else (
rem echo %2%332.exe >>  D:\Projects\VSrepository\BTresults.txt
set PGM=%2%332.exe
)
rem echo copy /y "%4" "%PGM%" >>  D:\Projects\VSrepository\BLAresults.txt
echo "C:\Program Files\7-Zip\7z.exe" u %ARC% %PGM% >>  D:\Projects\VSrepository\BLAresults.txt
rem copy /y "%4" "%PGM%" >>  D:\Projects\VSrepository\BLAresults.txt
copy /y "%4" "%PGM%"
rem "C:\Program Files\7-Zip\7z.exe" u %ARC% %PGM% >>  D:\Projects\VSrepository\BLAresults.txt
"C:\Program Files\7-Zip\7z.exe" u %ARC% %PGM%