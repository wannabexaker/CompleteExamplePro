@echo off
title CompleteExamplePro Docker Control
color 0A

:MENU
cls
echo ===============================================
echo      CompleteExamplePro - Docker Controller
echo ===============================================
echo.
echo [1] Start containers
echo [2] Stop containers
echo [3] Rebuild containers and database
echo [0] Exit
echo.
set /p choice=Select an option: 

if "%choice%"=="1" goto START
if "%choice%"=="2" goto STOP
if "%choice%"=="3" goto REBUILD
if "%choice%"=="0" exit
goto MENU

:START
echo Starting containers...
docker compose up
pause
goto MENU

:STOP
echo Stopping containers...
docker compose down
pause
goto MENU

:REBUILD
echo Rebuilding containers (including database)...
docker compose down -v
docker compose up --build
pause
goto MENU
