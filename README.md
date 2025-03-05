# P_02

Two table CRUD Operation.....

-> Additional : Combine data from two tables

-> Tables : course & student

-> Structure :
  course - 
      CREATE TABLE [dbo].[course] (
          [cId]   INT          IDENTITY (1, 1) NOT NULL,
          [cName] VARCHAR (50) NULL,
          PRIMARY KEY CLUSTERED ([cId] ASC)
      );

  student - 
      CREATE TABLE [dbo].[student] (
          [sId]    INT          IDENTITY (1, 1) NOT NULL,
          [sName]  VARCHAR (50) NULL,
          [sEmail] VARCHAR (50) NULL,
          [cId]    INT          NULL,
          PRIMARY KEY CLUSTERED ([sId] ASC)
      );
