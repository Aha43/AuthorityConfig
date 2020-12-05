create procedure authconfig.pr__set_configuration(
	@authority nvarchar(32),
	@json nvarchar(max),
	@uri nvarchar(256) = null,
	@description nvarchar(256) = null)
as begin
	if exists (select c.authority from authconfig.config c where c.authority = @authority) begin
		if not @uri = null begin
			if not @description = null begin
				update authconfig.config set json = @json, uri = @uri, description = @description where authority = @authority
			end else begin
				update authconfig.config set json = @json, uri = @uri where authority = @authority
			end
		end
		else begin
			if not @description = null begin
				update authconfig.config set json = @json, description = @description where authority = @authority
			end else begin
				update authconfig.config set json = @json where authority = @authority
			end
		end
	end 
	else begin
		insert into authconfig.config (authority, uri, json, description) values (@authority, @uri, @json, @description)
	end
end
go
