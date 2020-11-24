CREATE PROCEDURE [dbo].[Series_Save]
	@CreatedDate datetime,
	@Value decimal,
	@IsDelete bit
AS
	Begin Try
		Begin Tran
			if @IsDelete = 1 
				begin
					delete from Series where CreatedDate = @CreatedDate
				end
			else
				begin
					insert into Series (CreatedDate, Value)
					values (@CreatedDate, @Value)
				end
		Commit Tran
	End Try
	Begin Catch
		Rollback Tran
	End Catch

