create table authconfig.config (
	authority nvarchar(32) not null primary key,
	uri nvarchar(256) not null,
	json nvarchar(max) not null,
	description nvarchar(256) null
)
go