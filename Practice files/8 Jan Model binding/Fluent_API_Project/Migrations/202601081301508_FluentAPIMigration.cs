namespace Fluent_API_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPIMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.DeptID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Departments_DeptID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Departments_DeptID)
                .Index(t => t.Departments_DeptID);
            
            CreateStoredProcedure(
                "dbo.Employee_Insert",
                p => new
                    {
                        EmployeeName = p.String(),
                        Salary = p.Decimal(precision: 18, scale: 2),
                        Departments_DeptID = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Employees]([EmployeeName], [Salary], [Departments_DeptID])
                      VALUES (@EmployeeName, @Salary, @Departments_DeptID)
                      
                      DECLARE @EmployeeId int
                      SELECT @EmployeeId = [EmployeeId]
                      FROM [dbo].[Employees]
                      WHERE @@ROWCOUNT > 0 AND [EmployeeId] = scope_identity()
                      
                      SELECT t0.[EmployeeId]
                      FROM [dbo].[Employees] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[EmployeeId] = @EmployeeId"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Update",
                p => new
                    {
                        EmployeeId = p.Int(),
                        EmployeeName = p.String(),
                        Salary = p.Decimal(precision: 18, scale: 2),
                        Departments_DeptID = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Employees]
                      SET [EmployeeName] = @EmployeeName, [Salary] = @Salary, [Departments_DeptID] = @Departments_DeptID
                      WHERE ([EmployeeId] = @EmployeeId)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Delete",
                p => new
                    {
                        EmployeeId = p.Int(),
                        Departments_DeptID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employees]
                      WHERE (([EmployeeId] = @EmployeeId) AND (([Departments_DeptID] = @Departments_DeptID) OR ([Departments_DeptID] IS NULL AND @Departments_DeptID IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Employee_Delete");
            DropStoredProcedure("dbo.Employee_Update");
            DropStoredProcedure("dbo.Employee_Insert");
            DropForeignKey("dbo.Employees", "Departments_DeptID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Departments_DeptID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
