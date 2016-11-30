-- check for orphaned db sql accounts / and or list  users mapped to login
select
    dp.name [user_name]
    ,dp.type_desc [user_type]
    ,isnull(sp.name,'Orhphaned!') [login_name]
    ,sp.type_desc [login_type]
from   
    sys.database_principals dp
    left join sys.server_principals sp on (dp.sid = sp.sid)
where
    dp.type in ('S','U','G')
    and dp.principal_id >4
order by sp.name

go
--


sp_change_users_login 'Report'


-- if different / same - should be same
select name "LoginName", sid "LoginSID" from sys.syslogins where name = 'playsqluser'
go
select name "UserName", sid "UserSID" from sys.sysusers where name = 'playsqluser'
go

-- if different above then fix below
EXEC sp_change_users_login 'Auto_Fix', 'playsqluser'







-- if login not availble in new server where you're restoring on to then this creates login
-- see https://www.youtube.com/watch?v=m6BuToHFmrU

EXEC sp_change_users_login 'Auto_Fix' , 'playsqluser', null, 'playsqluser'


