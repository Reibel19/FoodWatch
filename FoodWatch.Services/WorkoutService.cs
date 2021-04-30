using FoodWatch.Data;
using FoodWatch.Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Services
{
    public class WorkoutService
    {
        private readonly Guid _userId;

        public WorkoutService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkout(WorkoutCreate model)
        {
            var entity = new Workout()
            {
                OwnerId = _userId,
                Name = model.Name,
                Time = model.Time,
                Type = model.Type,
                Intensity = model.Intensity,
                Details = model.Details
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkoutListItem> GetWorkouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Workouts
                                .Where(e => e.OwnerId == _userId)
                                .Select(e => new WorkoutListItem
                                {
                                    WorkoutId = e.WorkoutId,
                                    Name = e.Name,
                                    Time = e.Time
                                });
                return query.ToArray();
            }
        }

        public WorkoutDetail GetWorkoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Workouts
                                .Single(e => e.WorkoutId == id && e.OwnerId == _userId);
                return new WorkoutDetail
                {
                    WorkoutId = entity.WorkoutId,
                    Name = entity.Name,
                    Time = entity.Time,
                    Type = entity.Type,
                    Intensity = entity.Intensity,
                    Details = entity.Details
                };
            }
        }

        public bool UpdateWorkout(WorkoutEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Workouts
                                .Single(e => e.WorkoutId == model.WorkoutId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Time = model.Time;
                entity.Type = model.Type;
                entity.Intensity = model.Intensity;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkout(int workoutId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == workoutId && e.OwnerId == _userId);

                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
