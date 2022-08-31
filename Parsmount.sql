CREATE DATABASE Parsmount;

use parsmount;

CREATE TABLE [dbo].[admin](
	[admin_id] [int] NOT NULL identity PRIMARY KEY,
	[first_name] [varchar](25) NOT NULL,
	[last_name] [varchar](25) NOT NULL,
	[gender] [char](6) ,
	[email] [varchar](50) NOT NULL,
	[phone] [char](15) ,
	[address_id] [int] ,
	[password] [varchar](50) NOT NULL,
 );

CREATE TABLE [dbo].[address](
	[address_id] [int] NOT NULL identity PRIMARY KEY,
	[street_number] [int] NOT NULL,
	[street_name] [varchar](50) NOT NULL,
	[apartment_number] [int] NULL,
	[city] [varchar](25) NOT NULL,
	[province] [varchar](25) NOT NULL,
	[post_code] [char](8) NOT NULL,
	[country] [varchar](50) NOT NULL
);

ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id]);

CREATE TABLE [dbo].[event](
	[event_id] [int] NOT NULL identity PRIMARY KEY,
	[event_name] [varchar](25) NOT NULL,
	[date_time] [datetime] NOT NULL,
	[address_id] [int] NOT NULL,
	[category] [varchar](25) NOT NULL,
	[max_nember] [int] NOT NULL,
	[description] [varchar](100) NULL
);

ALTER TABLE [dbo].[event]  WITH CHECK ADD  CONSTRAINT [FK_event_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id]);

CREATE TABLE [dbo].[member](
	[member_id] [int] NOT NULL identity PRIMARY KEY,
	[first_name] [varchar](25) NOT NULL,
	[last_name] [varchar](25) NOT NULL,
	[birth_date] [date] ,
	[gender] [varchar](6) ,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](15) ,
	[address_id] [int] ,
	[password] [varchar](50) NOT NULL
);

ALTER TABLE [dbo].[member]  WITH CHECK ADD  CONSTRAINT [FK_member_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id]);

CREATE TABLE [dbo].[invoice](
	[invoice_id] [int] NOT NULL identity PRIMARY KEY,
	[purchase_datetime] [datetime] NOT NULL,
	[quantity] [int] NOT NULL,
	[sum_price] [decimal](10, 2) NOT NULL,
	[tax] [decimal](10, 2) NOT NULL,
	[total_amount] [decimal](10, 2) NOT NULL,
	[member_id] [int] NOT NULL
);

ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [FK_invoice_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id]);

CREATE TABLE [dbo].[member_event](
	[member_id] [int] NOT NULL,
	[event_id] [int] NOT NULL
);

ALTER TABLE [dbo].[member_event]  WITH CHECK ADD  CONSTRAINT [FK_member_event_event] FOREIGN KEY([event_id])
REFERENCES [dbo].[event] ([event_id]);

ALTER TABLE [dbo].[member_event]  WITH CHECK ADD  CONSTRAINT [FK_member_event_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id]);

CREATE TABLE [dbo].[ticket](
	[ticket_id] [int] NOT NULL identity PRIMARY KEY,
	[holder_name] [varchar](50) NOT NULL,
	[event_id] [int] NOT NULL,
	[age_group] [char](10) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[member_id] [int] NOT NULL,
	[invoice_id] [int] NULL
);

ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_event] FOREIGN KEY([event_id])
REFERENCES [dbo].[event] ([event_id]);

ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_invoice] FOREIGN KEY([invoice_id])
REFERENCES [dbo].[invoice] ([invoice_id]);

ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id]);