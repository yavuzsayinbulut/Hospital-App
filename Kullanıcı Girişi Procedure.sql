USE HastaneOtomasyonu
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE sp_yetkiKontrol
	(

	@TC bigint,
	@Sifre nchar(10)
	)
AS
BEGIN

	   select Gorevi from Personel where TC=@TC and Sifre=@Sifre 
	 
	return 1;	
	END;
	begin
	return 0
	end;                

