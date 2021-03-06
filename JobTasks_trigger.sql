USE [IPD-New]
GO
/****** Object:  Trigger [dbo].[UPDATE_TASK_TRG ]    Script Date: 03/29/2020 10:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[UPDATE_TASK_TRG ]
   ON  [dbo].[JobTasks]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @JobIdNew INT
	DECLARE @TaskIdNew INT
	DECLARE @ReleaseFlagNew  BIT
    DECLARE @OnShelfFlagNew  BIT
	DECLARE @ShelfNumberNew VARCHAR(50)
	DECLARE @OutboundFlagNew BIT
	DECLARE @McLoadFlagNew BIT
	DECLARE @StartFlagNew BIT
	DECLARE @McFinishFlagNew BIT
	DECLARE @McUnloadFlagNew BIT
	DECLARE @QcStatusNew  VARCHAR(50)
	
	DECLARE @JobIdOld INT
	DECLARE @TaskIdOld INT
	DECLARE @ReleaseFlagOld  BIT
    DECLARE @OnShelfFlagOld  BIT
	DECLARE @ShelfNumberOld VARCHAR(50)
	DECLARE @OutboundFlagOld BIT
	DECLARE @McLoadFlagOld BIT
	DECLARE @StartFlagOld BIT
	DECLARE @McFinishFlagOld BIT
	DECLARE @McUnloadFlagOld BIT
	DECLARE @QcStatusOld  VARCHAR(50)
 
    SELECT @JobIdNew = inserted.JobEntityId,
		   @TaskIdNew = inserted.TaskId,
		   @ReleaseFlagNew = inserted.ReleaseFlag,
		   @OnShelfFlagNew = inserted.OnShelfFlag,
		   @ShelfNumberNew = inserted.ShelfNumber,
		   @OutboundFlagNew = inserted.OutboundFlag,
		   @McLoadFlagNew = inserted.McLoadFlag,
		   @StartFlagNew = inserted.StartFlag,
		   @McFinishFlagNew=inserted.McFinishFlag,
		   @McUnloadFlagNew=inserted.McUnloadFlag,
		   @QcStatusNew=inserted.QCStatus
      FROM inserted
	  
    SELECT @JobIdOld = deleted.JobEntityId,
		   @TaskIdOld = deleted.TaskId,
		   @ReleaseFlagOld = deleted.ReleaseFlag,
		   @OnShelfFlagOld = deleted.OnShelfFlag,
		   @ShelfNumberOld = deleted.ShelfNumber,
		   @OutboundFlagOld = deleted.OutboundFlag,
		   @McLoadFlagOld = deleted.McLoadFlag,
		   @StartFlagOld = deleted.StartFlag,
		   @McFinishFlagOld = deleted.McFinishFlag,
		   @McUnloadFlagOld = deleted.McUnloadFlag,
		   @QcStatusOld = deleted.QCStatus
      FROM deleted	  

	if (@OutboundFlagNew = 1 AND @OutboundFlagNew <> @OutboundFlagOld)
		begin
			--Set Product lot to Availbale
			--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
			--WHERE combind_location = @ShelfNumberNew

			INSERT INTO [TaskTransactionLogs]
					   ([JobEntityId]
					   ,[TaskEntityTaskId]
					   ,[TaskId]
					   ,[ActionName]
					   ,[ActionTimeStamp]
					   ,[LogMessages])
				 VALUES
					   (@JobIdNew
					   ,@TaskIdNew
					   ,@TaskIdNew
					   ,'OUTBOUND'
					   ,CURRENT_TIMESTAMP
					   ,'')
		end


	if (@ReleaseFlagNew = 1 AND @ReleaseFlagNew <> @ReleaseFlagOld)
		begin

			INSERT INTO [TaskTransactionLogs]
					   ([JobEntityId]
					   ,[TaskEntityTaskId]
					   ,[TaskId]
					   ,[ActionName]
					   ,[ActionTimeStamp]
					   ,[LogMessages])
				 VALUES
					   (@JobIdNew
					   ,@TaskIdNew
					   ,@TaskIdNew
					   ,'RELEASE'
					   ,CURRENT_TIMESTAMP
					   ,'')
		end



	if (@OnShelfFlagNew = 1 AND @OnShelfFlagNew <> @OnShelfFlagOld)
		begin
			--Set Product lot to Availbale
			--UPDATE inv_locations SET fill_flag = 1
			--WHERE combind_location = @ShelfNumberNew

			INSERT INTO [TaskTransactionLogs]
					   ([JobEntityId]
					   ,[TaskEntityTaskId]
					   ,[TaskId]
					   ,[ActionName]
					   ,[ActionTimeStamp]
					   ,[LogMessages])
				 VALUES
					   (@JobIdNew
					   ,@TaskIdNew
					   ,@TaskIdNew
					   ,'ON_SHELF'
					   ,CURRENT_TIMESTAMP
					   ,'')
		end


	if (@McLoadFlagNew = 1 AND @McLoadFlagNew <> @McLoadFlagOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
						   ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'MC_LOAD'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end

	if (@StartFlagNew = 1 AND @StartFlagNew <> @StartFlagOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
					       ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'START'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end
	if (@McFinishFlagNew = 1 AND @McFinishFlagNew <> @McFinishFlagOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
					       ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'MC_FINISH'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end
	if (@McUnloadFlagNew = 1 AND @McUnloadFlagNew <> @McUnloadFlagOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
					       ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'MC_UNLOAD'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end
	if (@QcStatusNew = 'PASS' AND @QcStatusNew <> @QcStatusOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
					       ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'QC_PASS'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end
		if (@QcStatusNew = 'NG' AND @QcStatusNew <> @QcStatusOld)
			begin
				--Set Product lot to Availbale
				--UPDATE inv_locations SET fill_flag = 0, reserve_flag = 0
				--WHERE combind_location = @ShelfNumberNew

				INSERT INTO [TaskTransactionLogs]
						   ([JobEntityId]
						   ,[TaskEntityTaskId]
					       ,[TaskId]
						   ,[ActionName]
						   ,[ActionTimeStamp]
						   ,[LogMessages])
					 VALUES
						   (@JobIdNew
						   ,@TaskIdNew
						   ,@TaskIdNew
						   ,'QC_NG'
						   ,CURRENT_TIMESTAMP
						   ,'')
			end
END
