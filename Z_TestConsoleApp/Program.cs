
using BLL;
using DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WAPIL;

IBookingWebApiInvoker helloWorld = new BookingWebApiInvoker("https://localhost:44363/api/", new HttpClient());

await TestHotels();

async Task TestHotels()
{
    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading hotels...");
    await GetHotels();

    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading hotel rooms...");
    await GetHotelRooms(1);


}

async Task GetHotels()
{
    HotelManager rep = new(helloWorld);
    var hotels = await rep.GetAsync();
    foreach (var hotel in hotels)
    {
        Console.WriteLine($"Hotel: {hotel.Name}");
    }
}

async Task<Hotel> GetHotel(int id)
{
    HotelManager repository = new(helloWorld);
    return await repository.GetByIdAsync(id);
}

async Task GetHotelRooms(int id)
{
    var hotel = await GetHotel(id);
    Console.WriteLine($"Hotel: {hotel.Name}");

    HotelManager rep = new(helloWorld);
    var rooms = await rep.GetHotelRoomsAsync(id);
    foreach (var room in rooms)
    {
        Console.WriteLine($"    Room: {room.Description}");
    }
}
