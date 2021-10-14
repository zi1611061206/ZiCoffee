insert into Bills(
BillId, CreatedDate, Total, Vat, AfterVat, 
RealPay, Status, LastedModify, UserId, TableId)
values(
newid(), GETDATE(), 130000, 0,0,
0,0,GETDATE(), 'd4604be6-f3a0-42c5-ae87-dc1454048b99', 'eadd097e-f007-47a3-9c8c-052570f5f61a')

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'691babec-e9c4-486a-9608-50bbb41a7b09', '5d3b9d7f-50c5-4c59-8ae3-003c711576fd', 2, 90000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'691babec-e9c4-486a-9608-50bbb41a7b09', '92466f2b-5051-4b41-9788-036ee5814eb7', 1, 40000)