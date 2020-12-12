create procedure authconfig.pr__get_authorities
as begin
	select
		c.authority 
	from authconfig.config c 
end