﻿using DataBaseProject.Services;
using System.Linq.Expressions;
namespace DataBaseProject.MainMenu;
internal class MainMenuCourse
{
    private readonly CourseService _courseService;

    public MainMenuCourse(CourseService courseService)
    {
        _courseService = courseService;
    }
    public void AddNewCourse()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Course--");

            Console.Write("Course Name: ");
            var courseName = Console.ReadLine()!;

            var newCourse = _courseService.CreateCourse(courseName);
            if (newCourse != null)
            {
                Console.Clear();
                Console.WriteLine("The course is now added to the list.");
                Console.ReadLine();
            }
        }
        catch(Exception ex) 
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public void ShowAllCourses()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Courses in our System");

            var courses = _courseService.GetAllCourses();
            foreach (var course in courses)
            {
                Console.WriteLine($"\n{course.CourseName}");
            }
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public void ShowOneCourseById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Course");
            Console.Write("Type in the course ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var course = _courseService.GetCourseById(id);
            if (course != null)
            {
                Console.WriteLine($"Course with the ID: {id}");
                Console.WriteLine($"\n{course.CourseName}");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }

    public void UpdateCourse()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Course");
            Console.Write("Type Course Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var course = _courseService.GetCourseById(id);
            if (course != null)
            {
                Console.WriteLine($"{course.CourseName}");

                Console.Write("New Course: ");
                course.CourseName = Console.ReadLine()!;

                var updatedCourse = _courseService.UpdateCourse(course);
                Console.Clear();
                Console.WriteLine("Course updated!");
                Console.ReadKey();
            }
        }
        catch(Exception ex) 
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public void DeleteCourseById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Course");
            Console.Write("Course ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var course = _courseService.GetCourseById(id);
            if (course != null)
            {
                Console.WriteLine($"You are now deleting {course.CourseName}.");
                _courseService.DeleteCourse(id);
                Console.WriteLine("Course Deleted!");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
