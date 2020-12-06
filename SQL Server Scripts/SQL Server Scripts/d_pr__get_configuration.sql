create procedure authconfig.pr__get_configuration(
	@authority nvarchar(32))
as begin
	select
		c.authority,
		c.uri,
		c.json,
		c.description 
	from authconfig.config c where c.authority = authority 
end