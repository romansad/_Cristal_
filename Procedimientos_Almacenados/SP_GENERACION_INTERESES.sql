USE [M_VPSA_V3]
GO

/****** Object:  StoredProcedure [dbo].[GENERACION_INTERESES]    Script Date: 08/09/2021 11:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- PROCESO DE GENERACION DE INTERESES
CREATE PROCEDURE [dbo].[GENERACION_INTERESES]
AS
-- DECLARACIÓN DE VARIABLES DE TRABAJO
DECLARE @id_impuesto INT, @importe_final DECIMAL 
declare @contador int=0		
declare @anio varchar(4)
set @anio=YEAR(GetDate())
declare @mes varchar(2)
set @mes=MONTH(GetDate())
DeCLARE @dia varchar(2)
 set @dia=DAY(GetDate())
		
-- DECLARACIÓN DEL CURSOR
DECLARE MI_CURSOR CURSOR FOR
SELECT I.IdImpuesto as id_impuesto, I.ImporteFinal as importe_final
from IMPUESTOINMOBILIARIO I
where I.Año=@anio AND I.mes = @mes and  I.Estado = 0 and @dia>10

-- APERTURA DEL CURSOR
OPEN MI_CURSOR
-- LECTURA DEL PRIMER REGISTRO
declare @importe_int decimal
declare @interes decimal
FETCH NEXT FROM MI_CURSOR INTO @id_impuesto, @importe_final;
-- RECORRER EL CURSOS MIENTRAS HAYAN REGISTROS
WHILE @@FETCH_STATUS=0 BEGIN
	set @importe_int = 0
	set @interes = 0
	set @importe_int = @importe_final * 1.03
	set @interes = @importe_int - @importe_final
	UPDATE IMPUESTOINMOBILIARIO SET InteresValor=@interes,ImporteFinal=@importe_int where IdImpuesto = @id_impuesto
set @contador=+1		
FETCH NEXT FROM MI_CURSOR INTO @id_impuesto, @importe_final;

END 
--if(@contador>0)
	INSERT INTO CONTROL_PROCESOS(IdProceso) VALUES (2)
	--; 
CLOSE MI_CURSOR
-- LIBERAR EL RECURSO
DEALLOCATE MI_CURSOR;


GO

