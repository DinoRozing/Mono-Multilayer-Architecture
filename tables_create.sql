CREATE TABLE "User" (
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(30) NOT NULL,
    "LastName" VARCHAR(30) NOT NULL,
    "Email" VARCHAR(100) UNIQUE NOT NULL,
	"IsDeleted" BOOLEAN DEFAULT FALSE NOT NULL,
	"DateCreated" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE "Motorcycle" (
    "Id" SERIAL PRIMARY KEY,
    "Make" VARCHAR(30) NOT NULL,
    "Model" VARCHAR(30) NOT NULL,
    "Year" INT NOT NULL,
	"IsDeleted" BOOLEAN DEFAULT FALSE NOT NULL,
	"CreatedByUserId" INT,
	"UpdatedByUserId" INT,
	"DateCreated" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY ("CreatedByUserId") REFERENCES "User"("Id"),
    FOREIGN KEY ("UpdatedByUserId") REFERENCES "User"("Id")
);