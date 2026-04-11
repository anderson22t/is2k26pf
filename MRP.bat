@echo off
setlocal enabledelayedexpansion
color 0A

echo ======================================================
echo SISTEMA DE COMPILACION GLOBAL - MRP G1 (ULTIMATE)
echo ======================================================

:: --- CONFIGURACION DE RUTAS ---
set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
set "ROOT_DIR=%~dp0"
set "HOTELERIA_DIR=C:\asis2k25p2\codigo\modulos\hoteleria"
set "MRP_MAINT_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\Mantenimientos"
set "MRP_DLLS_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\DLLS"
set "MRP_NAV_TRANS_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\NavegadorTransaccionalMVC"
set "MRP_MVC_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\MVC_MRP"

:: Verificacion de MSBuild
if not exist "%MSBUILD_PATH%" (
    set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
)

cd /d "%ROOT_DIR%"
if not exist "logs" mkdir logs

:: ==========================================================
:: 1. CICLOS DE COMPILACION BASE + NAVEGADOR TRANSACCIONAL
:: ==========================================================
for /L %%i in (1,1,4) do (
    echo.
    echo CICLO %%i: Compilando Componentes Base...
    call :CompilarModulo CONSULTAS
    call :CompilarModulo REPORTEADOR
    call :CompilarModulo SEGURIDAD
    call :CompilarModulo NAVEGADOR_TRANSACCIONAL
    call :CompilarModulo NAVEGADOR
)

:: ==========================================================
:: 2. COMPILACION DINAMICA DE DLLS (NUEVO)
:: ==========================================================
echo.
color 0E
echo [+] Compilando Carpeta de DLLS Dinamica...
if exist "%MRP_DLLS_DIR%" (
    for /r "%MRP_DLLS_DIR%" %%d in (*.csproj) do (
        echo    -> DLL: %%~nxd
        "%MSBUILD_PATH%" "%%d" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_dlls_log.txt" 2>&1
    )
)

:: ==========================================================
:: 3. COMPILAR HOTELERIA
:: ==========================================================
echo.
color 0A
echo [+] Compilando Soluciones de Hoteleria...
for /r "%HOTELERIA_DIR%" %%f in (*.sln) do (
    "%MSBUILD_PATH%" "%%f" /p:Configuration=Debug /m /v:m >> "logs\hoteleria_log.txt" 2>&1
)

:: ==========================================================
:: 4. COMPILACION DINAMICA MANTENIMIENTOS MRP
:: ==========================================================
echo.
color 0B
echo [+] Compilando Mantenimientos MRP Dinamicamente...
if exist "%MRP_MAINT_DIR%" (
    for /L %%P in (1,1,2) do (
        for /r "%MRP_MAINT_DIR%" %%p in (*.csproj) do (
            echo    -> Mantenimiento: %%~nxp
            "%MSBUILD_PATH%" "%%p" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_maint_log.txt" 2>&1
        )
    )
)

:: ==========================================================
:: 5. COMPILAR MVC_MRP (PROYECTO PRINCIPAL)
:: ==========================================================
echo.
echo [+] Compilando MVC_MRP Principal...
if exist "%MRP_MVC_DIR%" (
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Modelo_MRP\Capa_Modelo_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Controlador_MRP\Capa_Controlador_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Vista_MRP\Capa_Vista_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    echo    [OK] MVC_MRP Procesado.
)

echo.
echo COMPILACION FINALIZADA COMPLETAMENTE.
pause
exit /b 0

:: ==========================================================
:: FUNCION: COMPILAR MODULOS (BASE Y ESPECIFICOS)
:: ==========================================================
:CompilarModulo
if /I "%1"=="CONSULTAS" (
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Modelo_Componente_Consultas\Capa_Modelo_Componente_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Controlador_Componente_Consultas\Capa_Controlador_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Vista_Componente_Consultas\Capa_Vista_Componente_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Modelo_Componente_Consultas\Capa_Modelo_Componente_Consultas_Simples.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Controlador_Componente_Consultas\Capa_Controlador_Componente_Consultas_Simples.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Vista_Componente_Consultas_simples\Capa_Vista_Componente_Consultas_simples.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
)
if /I "%1"=="REPORTEADOR" (
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Modelo_Reporteador\Capa_Modelo_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Controlador_Reporteador\Capa_Controlador_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Vista_Reporteador\Capa_Vista_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
)
if /I "%1"=="SEGURIDAD" (
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaModelo\Capa_Modelo_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaControlador\Capa_Controlador_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaVista\Capa_Vista_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
)
if /I "%1"=="NAVEGADOR_TRANSACCIONAL" (
    "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaModeloNavegador\CapaModeloNavegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\mrp_nav_trans_log.txt 2>&1
    "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaControladorNavegador\CapaControladorNavegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\mrp_nav_trans_log.txt 2>&1
    "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaVistaNavegador\CapaVistaNavegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\mrp_nav_trans_log.txt 2>&1
)
if /I "%1"=="NAVEGADOR" (
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaModeloNavegador\Capa_Modelo_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaControladorNavegador\Capa_Controlador_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaVistaNavegador\Capa_Vista_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
)
exit /b 0