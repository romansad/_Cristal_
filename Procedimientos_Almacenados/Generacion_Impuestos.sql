USE [M_VPSA_V3]
GO

/****** Object:  StoredProcedure [dbo].[GENERACION_IMPUESTOS_LOTES]    Script Date: 08/09/2021 12:04:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[GENERACION_IMPUESTOS_LOTES]
--@anio int 
AS
-- DECLARACIÓN DE VARIABLES DE TRABAJO
DECLARE @lote INT, @Valuacion DECIMAL, @TOTAL DECIMAL ,@Y1 int, @Y int,
@MONTO decimal
SET @TOTAL=0 

declare @anio varchar(4)
set @anio=YEAR(GetDate())
declare @FechaInicio datetime
declare @FechaVencimiento datetime
--declare @OverallEndDate	date
declare @contador        int =0
Declare @calculo_impuesto decimal
set @FechaInicio = @anio+'-01-01'
set @FechaVencimiento = dateadd( dd,9 ,@FechaInicio)
		
-- DECLARACIÓN DEL CURSOR
DECLARE MI_CURSOR CURSOR FOR
SELECT L.IdLote as lote , L.ValuacionTotal as Valuacion
from LOTE L

-- APERTURA DEL CURSOR
OPEN MI_CURSOR
-- LECTURA DEL PRIMER REGISTRO
FETCH NEXT FROM MI_CURSOR INTO @lote, @Valuacion;
-- RECORRER EL CURSOS MIENTRAS HAYAN REGISTROS
WHILE @@FETCH_STATUS=0 BEGIN
while(@contador < 12) begin
      SET @calculo_impuesto = @valuacion * 0.0005
INSERT INTO IMPUESTOINMOBILIARIO(Mes,Año,FechaEmision,FechaVencimiento,Estado,ImporteBase,ImporteFinal,IdLote)
     VALUES(@contador+1,YEAR(GETDATE()),GETDATE(),@FechaVencimiento,0,@calculo_impuesto,@calculo_impuesto,@lote)

       set @FechaInicio = CONVERT( varchar(10),@FechaInicio, 4)
        set @FechaVencimiento = CONVERT( varchar(10),@FechaVencimiento, 4)
        set @FechaInicio= dateadd( mm,1 ,@FechaInicio)
        set @FechaVencimiento = dateadd( dd,9 ,@FechaInicio)
		set @contador += 1
		SET @calculo_impuesto = 0
end
FETCH NEXT FROM MI_CURSOR INTO @lote, @Valuacion;
set @contador =0
END 
INSERT INTO CONTROL_PROCESOS(IdProceso) VALUES (1)  
CLOSE MI_CURSOR
-- LIBERAR EL RECURSO

DEALLOCATE MI_CURSOR;

GO

