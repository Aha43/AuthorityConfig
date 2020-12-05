create procedure authconfig.pr__get_configuration(
	@authority nvarchar(32))
as begin
	select * from authconfig.config c where c.authority = authority 
end