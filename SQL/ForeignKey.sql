use EventManagement

--First add the column in the table you wanted to have the foreign key. 
alter table eventdetails add userId int;

--later add the foreign key constraint and point to the same column you just added for the reference. 
alter table	eventdetails 
add constraint FK_UserID
foreign key (UserID)
references Users(userid)