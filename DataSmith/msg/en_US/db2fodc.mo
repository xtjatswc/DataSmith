  �          V      1   V      s   V      �   V      �   V      4  V        V      �  V       �  V   !     V   "   E  V   #   �  V   $   �  V   2     V   3   3  V   d   c  V   e   �  V   �   �  T   "%1S": Unable to run DB2 call out script, "%2S". "%1S": Unexpected internal error detected. Signal "%2S" received. "%1S": Error: User must have SYSADM authority to run db2fodc. "%1S": Error: "%1S" could not get the list of databases. "%1S": Error: "%1S" could not get the list of database partition numbers. "%1S": Error: At least one of the databases specified is not an active db. "%1S": Error: unknown "%2S" suboption: "%3S". "%1S": Error: database expected. "%1S": Error: an option was expected instead of "%2S". "%1S": Error: It is necessary to specify -hang option at least. "%1S": Error: -db and -alldbs can not be activated at the same time. "%1S": Error: -hang full and -hang basic can not be activated at the same time. "%1S": Error: Database partition number expected. "%1S": List of active databases: "%2S" "%1S": List of active partition numbers: "%2S". FODC package has been successfully collected in directory "%1S". Open "%1S" in that directory for details of collected data. 
db2fodc (DB2 First Ocurrence Data Capture) collects data for problem 
determination for hangs or severe performance problems. Specify the type of 
outage detected, and optionally the mode that you want to execute (full or 
basic). Additionaly you may specify the database(s) and the database 
partition numbers that are suspicious to be affected. 

Usage: db2fodc -hang [full | basic] [-db <database_name> | -alldbs]
[ -dbpartitionnum <dbpartition_nums> | -alldbpartitionnums ]

db2fodc options and suboptions: 
    -hang 
         full 
         basic
    -db <database_names>
    -alldbs
    -dbpartitionnum <dbpartition_nums>
    -alldbpartitionnums
    -help 

db2fodc options: 
 -hang: If the system appears to be hung. If mode (full or basic) is not 
 specified, you will be asked after basic collection.
 -db: Name of the database affected by the outage. Format for database names
  is as follows: sample,dbname1,dbname2
 -alldbs: All active databases will be used for the data collection. This 
 option is active by default.
 -dbpartitionnum <dbpartition_nums>: Collects FODC data related to all 
 the specified database partition numbers. Format example: -dbpartitionnum 1,2,3
 -alldbpartitionnums: Specifies that this command is to run on all active
  database partition servers in the instance. db2fodc will report 
  information from database partition servers on the same physical 
  machine that db2fodc is being run on.
 -help : Prints this help

Example: db2fodc -hang
 