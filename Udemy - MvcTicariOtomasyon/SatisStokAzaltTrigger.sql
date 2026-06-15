create trigger SatisStokAzalt
on SatisHarekets
after insert
as
Declare @urunid int
Declare @adet int
select @urunid=UrunId,@adet=Adet from inserted
Update Uruns set Stok-=@adet where UrunId=@urunid