create table authconfig.config (
	authority nvarchar(32) primary key,
	uri nvarchar(256) not null,
	json nvarchar(max) not null,
	description nvarchar(256) null
)
go