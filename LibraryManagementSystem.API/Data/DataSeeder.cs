using LibraryManagementSystem.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.API.Data
{
    public class DataSeeder
    {
        public static async Task SeedLMSData(LMSDbContext lmsContext)
        {
            // Seed Default Books (if not exists)
            if (!await lmsContext.Books.AnyAsync())
            {
                var books = new List<Book>
                {
                    new Book
        {
            Id = 1,
            Title = "Chasing Cassandra",
            Author = "Lisa Kleypas",
            Description = "Railway magnate Tom Severin is wealthy and powerful enough to satisfy any desire as soon as it arises. Anything—or anyone—is his for the asking. It should be simple to find the perfect wife—and from his first glimpse of Lady Cassandra Ravenel, he’s determined to have her. But the beautiful and quick-witted Cassandra is equally determined to marry for love—the one thing he can’t give.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1565325290i/44285731.jpg"
        },
        new Book
        {
            Id = 2,
            Title = "Daydream",
            Author = "Hannah Grace",
            Description = "When procrastination lands him in a difficult class with his least favorite professor, Henry Turner knows he’s going to have to work extra hard to survive his junior year of college. And now with his new role as ice hockey captain – which he didn’t even want – Henry absolutely cannot fail. Enter Halle Jacobs, a fellow junior who finds herself befriended by Henry when he accidentally crashes her book club.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1699948241i/198647119.jpg"
        },
        new Book
        {
            Id = 3,
            Title = "By Any Other Name",
            Author = "Jodi Picoult",
            Description = "Two women, centuries apart—one of whom is the real author of Shakespeare’s plays—are both forced to hide behind another name to make their voices heard. In 1581, Emilia Bassano—like most young women of her day—is allowed no voice of her own. But as the Lord Chamberlain’s mistress, she has access to all theater in England, and finds a way to bring her work to the stage secretly. And yet, creating some of the world’s greatest dramatic masterpieces comes at great cost: by paying a man for the use of his name, she will write her own out of history.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1706883298i/203337138.jpg"
        },
        new Book
        {
            Id = 4,
            Title = "On Call",
            Author = "Anthony Fauci",
            Description = "Anthony Fauci is arguably the most famous – and most revered – doctor in the world today. His role guiding America sanely and calmly through Covid (and through the torrents of Trump) earned him the trust of millions during one of the most terrifying periods in modern American history, but this was only the most recent of the global epidemics in which Dr. Fauci played a major role. His crucial role in identifying HIV and bringing AIDS into sympathetic public view and his leadership in navigating the Ebola, SARS, West Nile, and anthrax crises make him truly an American hero.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1715719932i/207689829.jpg"
        }, new Book
        {
            Id = 5,
            Title = "Burn of the Everflame",
            Author = "Penn Cole",
            Description = "War has overtaken Emarion. In the north, Ophiucae and his army of bloodthirsty mortals seek to eradicate all Descended from the continent. In the south, the Guardians of the Everflame lie in wait, plotting a rebellion generations overdue.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1708187082i/208818334.jpg"
        },
        new Book
        {
            Id = 6,
            Title = "Fourth Wing",
            Author = "Rebecca Yarros",
            Description = "Twenty-year-old Violet Sorrengail was supposed to enter the Scribe Quadrant, living a quiet life among books and history. Now, the commanding general—also known as her tough-as-talons mother—has ordered Violet to join the hundreds of candidates striving to become the elite of Navarre: dragon riders.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1701980900i/61431922.jpg"
        },
        new Book
        {
            Id = 7,
            Title = "Happy Place",
            Author = "Emily Henry",
            Description = "Harriet and Wyn have been the perfect couple since they met in college—they go together like salt and pepper, honey and tea, lobster and rolls. Except, now—for reasons they’re still not discussing—they don’t.",
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1660145160i/61718053.jpg"
        }
                };

                await lmsContext.Books.AddRangeAsync(books);
                await lmsContext.SaveChangesAsync();
            }
        }
    }
}
