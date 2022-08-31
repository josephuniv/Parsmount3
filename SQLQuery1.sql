create database ParsmountDB;

use ParsmountDB;

CREATE TABLE [dbo].[event] (
    [event_id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)  NOT NULL,
    [datetime]    DATETIME      NULL,
    [category]    VARCHAR (50)  NULL,
    [max_number]  INT           NULL,
    [description] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([event_id] ASC)
);

CREATE TABLE [dbo].[admin] (
    [admin_id]   INT          IDENTITY (1, 1) NOT NULL,
    [first_name] VARCHAR (50) NOT NULL,
    [last_name]  VARCHAR (50) NOT NULL,
    [gender]     VARCHAR(10)  NULL,
    [phone]      VARCHAR (20) NOT NULL,
    [email]      VARCHAR (50) NOT NULL,
    [password]   VARCHAR (20) NOT NULL,    
    PRIMARY KEY CLUSTERED ([admin_id] ASC)
);

