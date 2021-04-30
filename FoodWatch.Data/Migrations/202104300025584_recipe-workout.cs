namespace FoodWatch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeworkout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Recipe", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Recipe", "TotalServings", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Recipe", "TotalCalories", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "TotalCarbs", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "TotalProtein", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "TotalFat", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "Instructions", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Workout", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.Workout", "Type", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "Intensity", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "Details");
            DropColumn("dbo.Workout", "Intensity");
            DropColumn("dbo.Workout", "Type");
            DropColumn("dbo.Workout", "Time");
            DropColumn("dbo.Workout", "Name");
            DropColumn("dbo.Workout", "OwnerId");
            DropColumn("dbo.Recipe", "Instructions");
            DropColumn("dbo.Recipe", "CookTime");
            DropColumn("dbo.Recipe", "TotalFat");
            DropColumn("dbo.Recipe", "TotalProtein");
            DropColumn("dbo.Recipe", "TotalCarbs");
            DropColumn("dbo.Recipe", "TotalCalories");
            DropColumn("dbo.Recipe", "TotalCost");
            DropColumn("dbo.Recipe", "TotalServings");
            DropColumn("dbo.Recipe", "Name");
            DropColumn("dbo.Recipe", "OwnerId");
        }
    }
}
