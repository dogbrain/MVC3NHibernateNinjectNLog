MVC3NHibernateNinjectNLog
=========================
This is still a work in progress!

This is what I use for starting up an MVC3 project with NHibernate. Included in the project
 
* Fluent NHibernate
* Custom MembershipProvider and RoleProvider for to use NHibernate
* NLog (Set up to log messages from NHibernite to debug console only atm)
* Ninject dependency injection
* User administration
* NHibernate is set up to automaticly saving data. Se Infrastructure/Data/NHibernateSessionPerRequest.cs for info

Configuration
=============
The main configuration of the application is done in the Web.config. Under appsettings you can configure 
what enviroment you are running.
'    <!--
         Possible settings for Enviroment
         ###########################################
         Production             - will upgrade the database if not dropping any columns, 
         ProductionValidateOnly - Validates that the schema is correct only
         Development            - Development will clear database each time 
    -->
    <add key="Environment" value="Development" />'
Be sure to change this before taking your site into production.

Update the smtp settings in web.config also. At the moment it is configured to use gmail.

The application is set up to create two users admin and user both with the password 123456. The user has no roles and 
the admin has the role Admin. This can be changed in the file Infrastructure/Data/NHibernateSessionPerRequest.cs

Fluent NHibernate
-----------------
Uses the hibernate.cfg.xml file in the root folder. 
'<?xml version="1.0" encoding="utf-8" ?>
<!-- 
    Settings file for the database connection
    See http://nhforge.org/blogs/nhibernate/archive/2009/07/17/nhibernate-configuration.aspx
    For more information
--> 
<hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
  <session-factory>
    <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
    <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
    <property name="dialect">NHibernate.Dialect.MsSql2008Dialect</property>
    <property name="connection.connection_string">Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DevDatabase.mdf;Integrated Security=True;User Instance=True</property>
    <property name="show_sql">true</property>
  </session-factory>
</hibernate-configuration>'
As you can see it is set up to use a MSSql Express file in the data directory.

NLog
----
Can be configured in the NLog.config in the root directory.

Ninject
------- 
Can be configured in the App_Start/NinjectWebCommon.cs file.

TODO!
=====
This project was (as many) a bit of a hasty job. Should probably look into how to make it more pure (like using more 
dependency injection). Please feel free to help me improve this starter-kit!

Acknowledgements
================
This work is based on various other peoples works and put together by me. Many of the soloutions I found on the 
Net where not correct for me as they where either too complex or too simple for my taste. Unfortunatly I did not
keep all the links while putting this project together. So if you feel that your name or someones name is missing
from the list below please send and email to mikael@0hlsson.se and I will update the list.

Thanks to
---------
Troy Goode - For making https://github.com/TroyGoode/MembershipStarterKit from where I borrowed the user and role administration