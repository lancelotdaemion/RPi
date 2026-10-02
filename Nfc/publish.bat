cd "C:\src\RPi\Nfc"
REM dotnet publish -c Debug --runtime linux-arm64 --self-contained
dotnet publish -c Debug --runtime linux-arm64
xcopy "C:\src\RPi\Nfc\bin\Debug\net10.0\linux-arm64\publish" "X:\Src\RPi\Nfc" /E /I /Y

REM net use
REM net use X: /delete
REM net use X: \\sshfs\lancelotdaemion@raspberrypi