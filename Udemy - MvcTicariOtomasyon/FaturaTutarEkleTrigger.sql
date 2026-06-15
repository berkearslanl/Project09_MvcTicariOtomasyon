create trigger TutarEkle
on
FaturaKalems
after insert
as
declare @faturaid int
declare @tutar decimal(18,2)
select @faturaid=FaturaId,@tutar=Tutar from inserted
update Faturas set Toplam=Toplam + @tutar where FaturaId=@faturaid