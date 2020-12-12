create procedure authconfig.pr__get_authorities
as begin
	select
		c.authority,
		c.uri,
		c.description 
	from authconfig.config c 
end