CREATE TABLE [dbo].[LoginHistory] (
    [LoginHistoryID] INT IDENTITY(1, 1) NOT NULL,  -- Уникальный идентификатор записи
    [UserID] INT NOT NULL,                        -- Внешний ключ на пользователя
    [Login] NVARCHAR(50) NOT NULL,                -- Логин пользователя (дублируем для быстрого просмотра)
    [AttemptTime] DATETIME DEFAULT GETDATE() NOT NULL, -- Время попытки входа
    [Success] BIT NOT NULL,                       -- Успешность попытки входа (1 - успешная, 0 - неуспешная)
    PRIMARY KEY CLUSTERED ([LoginHistoryID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) -- Связываем с таблицей Users
);
