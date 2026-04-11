@echo off
setlocal enabledelayedexpansion
color 0A

echo ============================================
echo SISTEMA DE COMPILACION GLOBAL - MRP COMPLETO
echo ============================================

:: --- CONFIGURACION DE RUTAS ---
set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
set "ROOT_DIR=%~dp0"
set "HOTELERIA_DIR=C:\asis2k25p2\codigo\modulos\hoteleria"
set "MRP_MAINT_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\Mantenimientos"
set "MRP_MVC_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\MVC_MRP"

:: Verificacion de MSBuild
if not exist "%MSBUILD_PATH%" (
    set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
)

cd /d "%ROOT_DIR%"
if not exist "logs" mkdir logs

:: ==========================================================
:: 1. CICLOS DE COMPILACION BASE
:: ==========================================================
for /L %%i in (1,1,4) do (
    echo.
    echo CICLO %%i: Compilando Componentes Base...
    call :CompilarModulo CONSULTAS
    call :CompilarModulo REPORTEADOR
    call :CompilarModulo SEGURIDAD
    call :CompilarModulo NAVEGADOR
)

:: ==========================================================
:: 2. COMPILAR HOTELERIA
:: ==========================================================
echo.
echo [+] Compilando Soluciones de Hoteleria...
for /r "%HOTELERIA_DIR%" %%f in (*.sln) do (
    "%MSBUILD_PATH%" "%%f" /p:Configuration=Debug /m /v:m >> "logs\hoteleria_log.txt" 2>&1
)

:: ==========================================================
:: 3. COMPILACION DINAMICA MANTENIMIENTOS MRP
:: ==========================================================
echo.
color 0B
echo [+] Compilando Mantenimientos MRP...
if exist "%MRP_MAINT_DIR%" (
    for /L %%P in (1,1,2) do (
        for /r "%MRP_MAINT_DIR%" %%p in (*.csproj) do (
            echo    -> Compilando: %%~nxp
            "%MSBUILD_PATH%" "%%p" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_maint_log.txt" 2>&1
        )
    )
)

:: ==========================================================
:: 4. COMPILAR MVC_MRP (PROYECTO PRINCIPAL)
:: ==========================================================
echo.
echo [+] Compilando MVC_MRP Principal...
if exist "%MRP_MVC_DIR%" (
    :: Compilamos en orden: Modelo -> Controlador -> Vista
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Modelo_MRP\Capa_Modelo_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Controlador_MRP\Capa_Controlador_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Vista_MRP\Capa_Vista_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m >> "logs\mrp_mvc_log.txt" 2>&1
    
    if !errorlevel! == 0 (
        echo    [OK] MVC_MRP compilado con exito.
    ) else (
        echo    [ERROR] Fallo en la compilacion de MVC_MRP.
    )
) else (
    echo [X] No se encontro la ruta MVC_MRP: %MRP_MVC_DIR%
)

:: ==========================================================
:: 5. VERIFICACION FINAL
:: ==========================================================
echo.
color 0A
echo ============================================
echo VERIFICACION FINAL
echo ============================================
set "V1=codigo\componentes\consultas\Componente_Consultas\Capa_Vista_Componente_Consultas\bin\Debug\Capa_Vista_Componente_Consultas.dll"
if exist "%V1%" (echo [OK] DLL Consultas lista) else (echo [FALTA] DLL Consultas)

echo.
echo COMPILACION FINALIZADA COMPLETAMENTE.
pause
exit /b 0

:: ==========================================================
:: FUNCION: COMPILAR MODULOS BASE
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
if /I "%1"=="NAVEGADOR" (
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaModeloNavegador\Capa_Modelo_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaControladorNavegador\Capa_Controlador_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaVistaNavegador\Capa_Vista_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m >> logs\build_log.txt 2>&1
)
exit /b 0