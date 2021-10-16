insert into Bills(
BillId, CreatedDate, Total, Vat, AfterVat, 
RealPay, Status, LastedModify, UserId, TableId)
values(
newid(), GETDATE(), 130000, 0,0,
0,0,GETDATE(), 'd4604be6-f3a0-42c5-ae87-dc1454048b99', 'eadd097e-f007-47a3-9c8c-052570f5f61a')

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'99124672-07b9-4faf-97cd-d7deb66e5585', '5d3b9d7f-50c5-4c59-8ae3-003c711576fd', 2, 90000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'99124672-07b9-4faf-97cd-d7deb66e5585', '92466f2b-5051-4b41-9788-036ee5814eb7', 1, 40000)

insert into Bills(
BillId, CreatedDate, Total, Vat, AfterVat, 
RealPay, Status, LastedModify, UserId, TableId)
values(
newid(), GETDATE(), 165000, 0,0,
0,0,GETDATE(), 'd4604be6-f3a0-42c5-ae87-dc1454048b99', '089eb8ae-90e4-4a77-b3cf-0d4477efc258')

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'f5ed9e8d-e2bf-4d22-bef4-60733096fab9', '5d3b9d7f-50c5-4c59-8ae3-003c711576fd', 2, 90000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'f5ed9e8d-e2bf-4d22-bef4-60733096fab9', '92466f2b-5051-4b41-9788-036ee5814eb7', 1, 40000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'f5ed9e8d-e2bf-4d22-bef4-60733096fab9', '93ce879e-3448-4483-93cd-03775a2bf53b', 1, 35000)

insert into Bills(
BillId, CreatedDate, Total, Vat, AfterVat, 
RealPay, Status, LastedModify, UserId, TableId)
values(
newid(), GETDATE(), 105000, 0,0,
0,0,GETDATE(), 'd4604be6-f3a0-42c5-ae87-dc1454048b99', '7cbe505b-25e5-4f62-908d-1fdd4df8ddd0')

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'6091a88c-1ad4-4ebd-a3dd-8f31ea666cb3', '93ce879e-3448-4483-93cd-03775a2bf53b', 1, 35000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'6091a88c-1ad4-4ebd-a3dd-8f31ea666cb3', '4b7a0f55-00e0-49ea-a255-03de4c3ed07f', 1, 35000)

insert into BillDetails(
BillId, ProductId, Quantity, IntoMoney)
values(
'6091a88c-1ad4-4ebd-a3dd-8f31ea666cb3', 'a0a334a9-5df4-447b-9039-05f2ee8efc7d', 1, 35000)