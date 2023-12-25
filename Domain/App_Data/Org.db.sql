BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Dept" (
	"ID"	INTEGER NOT NULL,
	"ParentID"	INTEGER,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Manager"	TEXT NOT NULL,
	"AddDate"	TEXT NOT NULL,
	"UpdateDate"	TEXT NOT NULL,
	PRIMARY KEY("ID")
);
CREATE TABLE IF NOT EXISTS "Employee" (
	"ID"	INTEGER NOT NULL,
	"Account"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"DeptID"	INTEGER NOT NULL,
	"Title"	TEXT,
	"Arrival"	REAL NOT NULL,
	"Status"	INTEGER NOT NULL,
	"AddDate"	TEXT NOT NULL,
	"UpdateDate"	TEXT NOT NULL,
	PRIMARY KEY("ID")
);
CREATE TABLE IF NOT EXISTS "ZipCode" (
	"NO"	INTEGER NOT NULL,
	"Code"	INTEGER,
	"City"	TEXT,
	"Area"	TEXT,
	PRIMARY KEY("NO")
);
INSERT INTO "Dept" VALUES (1,0,'DB','資料庫管理','Lily','2023-01-01','2023-01-01');
INSERT INTO "Dept" VALUES (2,0,'AA00','人資部','Mandy','2023-01-01','2023-01-01');
INSERT INTO "Dept" VALUES (3,0,'CC00','資訊部','Ben','2023-01-01','2023-01-01');
INSERT INTO "Dept" VALUES (4,1,'BB00','客服部','Jung','2023-01-01','2023-01-01');
INSERT INTO "Dept" VALUES (5,2,'DD00','企劃部','Anne','2023-01-01','2023-01-01');
INSERT INTO "Employee" VALUES (1,'Lily','莉莉',1,NULL,'2023-02-05',1,'2023-02-05','2023-02-05');
INSERT INTO "Employee" VALUES (2,'Rola','蘿拉',1,NULL,'2018-05-01',1,'2018-05-01','2018-05-01');
INSERT INTO "Employee" VALUES (3,'Ben','班',3,NULL,'2012-07-10',1,'2012-07-10','2012-07-10');
INSERT INTO "ZipCode" VALUES (1,100,'台北市','中正區');
INSERT INTO "ZipCode" VALUES (2,103,'台北市','大同區');
INSERT INTO "ZipCode" VALUES (3,104,'台北市','中山區');
INSERT INTO "ZipCode" VALUES (4,104,'台北市','中山區');
INSERT INTO "ZipCode" VALUES (5,105,'台北市','松山區');
INSERT INTO "ZipCode" VALUES (6,106,'台北市','大安區');
INSERT INTO "ZipCode" VALUES (7,108,'台北市','萬華區');
INSERT INTO "ZipCode" VALUES (8,110,'台北市','信義區');
INSERT INTO "ZipCode" VALUES (9,111,'台北市','士林區');
INSERT INTO "ZipCode" VALUES (10,112,'台北市','北投區');
INSERT INTO "ZipCode" VALUES (11,113,'台北市','陽明山');
INSERT INTO "ZipCode" VALUES (12,114,'台北市','內湖區');
INSERT INTO "ZipCode" VALUES (13,115,'台北市','南港區');
INSERT INTO "ZipCode" VALUES (14,116,'台北市','文山區');
INSERT INTO "ZipCode" VALUES (15,117,'台北市','文山區景美');
INSERT INTO "ZipCode" VALUES (16,200,'基隆市','仁愛區');
INSERT INTO "ZipCode" VALUES (17,201,'基隆市','信義區');
INSERT INTO "ZipCode" VALUES (18,202,'基隆市','中正區');
INSERT INTO "ZipCode" VALUES (19,203,'基隆市','中山區');
INSERT INTO "ZipCode" VALUES (20,204,'基隆市','安樂區');
INSERT INTO "ZipCode" VALUES (21,205,'基隆市','暖暖區');
INSERT INTO "ZipCode" VALUES (22,206,'基隆市','七堵區');
INSERT INTO "ZipCode" VALUES (23,207,'新北市','萬里區');
INSERT INTO "ZipCode" VALUES (24,208,'新北市','金山區');
INSERT INTO "ZipCode" VALUES (25,209,'連江縣','南竿鄉');
INSERT INTO "ZipCode" VALUES (26,210,'連江縣','北竿鄉');
INSERT INTO "ZipCode" VALUES (27,211,'連江縣','莒光鄉');
INSERT INTO "ZipCode" VALUES (28,212,'連江縣','東引鄉');
INSERT INTO "ZipCode" VALUES (29,220,'新北市','板橋區');
INSERT INTO "ZipCode" VALUES (30,222,'新北市','深坑區');
INSERT INTO "ZipCode" VALUES (31,223,'新北市','石碇區');
INSERT INTO "ZipCode" VALUES (32,224,'新北市','瑞芳區');
INSERT INTO "ZipCode" VALUES (33,226,'新北市','平溪區');
INSERT INTO "ZipCode" VALUES (34,227,'新北市','雙溪區');
INSERT INTO "ZipCode" VALUES (35,231,'新北市','新店區');
INSERT INTO "ZipCode" VALUES (36,232,'新北市','坪林區');
INSERT INTO "ZipCode" VALUES (37,233,'新北市','烏來區');
INSERT INTO "ZipCode" VALUES (38,234,'新北市','永和區');
INSERT INTO "ZipCode" VALUES (39,235,'新北市','中和區');
INSERT INTO "ZipCode" VALUES (40,236,'新北市','土城區');
INSERT INTO "ZipCode" VALUES (41,237,'新北市','三峽區');
INSERT INTO "ZipCode" VALUES (42,238,'新北市','樹林區');
INSERT INTO "ZipCode" VALUES (43,239,'新北市','鶯歌區');
INSERT INTO "ZipCode" VALUES (44,241,'新北市','三重區');
INSERT INTO "ZipCode" VALUES (45,242,'新北市','新莊區');
INSERT INTO "ZipCode" VALUES (46,243,'新北市','泰山區');
INSERT INTO "ZipCode" VALUES (47,244,'新北市','林口區');
INSERT INTO "ZipCode" VALUES (48,247,'新北市','蘆洲區');
INSERT INTO "ZipCode" VALUES (49,248,'新北市','五股區');
INSERT INTO "ZipCode" VALUES (50,249,'新北市','八里區');
INSERT INTO "ZipCode" VALUES (51,251,'新北市','淡水區');
INSERT INTO "ZipCode" VALUES (52,252,'新北市','三芝區');
INSERT INTO "ZipCode" VALUES (53,253,'新北市','石門區');
COMMIT;
