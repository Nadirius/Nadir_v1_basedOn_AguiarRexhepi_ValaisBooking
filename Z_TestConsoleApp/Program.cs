
using BLL;
using DTO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WAPIL;

BookingWebApiInvoker helloWorld = new BookingWebApiInvoker(new HttpClient());

helloWorld._PleaseWAPI.BaseAddress = new Uri("https://localhost:44363/api/");
helloWorld._PleaseWAPI.DefaultRequestHeaders.Accept.Clear();
helloWorld._PleaseWAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


Console.WriteLine("###############################################################");
Console.WriteLine("###############################################################");
Console.WriteLine("Testing Hotel Regime...");

//await TestHotels();

Console.WriteLine("###############################################################");
Console.WriteLine("###############################################################");
Console.WriteLine("Testing Room Regime...");

await TestRooms();


Console.WriteLine("###############################################################");
Console.WriteLine("###############################################################");
Console.WriteLine("Testing Reservation Regime...");


Console.WriteLine("###############################################################");
Console.WriteLine("###############################################################");
Console.WriteLine("Testing Picture Regime...");


//############################################################################################################
// Rooms test methods
async Task TestRooms()
{
    Console.WriteLine("////////////////////");
    Console.WriteLine("////////////////////");
    Console.WriteLine("Reading hotels...");
    await GetRooms();
    Console.WriteLine();
    Console.WriteLine();


    //Console.WriteLine("////////////////////");
    //Console.WriteLine("////////////////////");
    //Console.WriteLine("Reading hotel (byID) rooms...");
    //await GetHotelRooms(1);
    //Console.WriteLine();
    //Console.WriteLine();

    //Console.WriteLine("////////////////////");
    //Console.WriteLine("////////////////////");
    //Console.WriteLine("Reading hotel locations...");
    //await GetHotelLocations();
    //Console.WriteLine();
    //Console.WriteLine();


    //Console.WriteLine("////////////////////");
    //Console.WriteLine("////////////////////");
    //Console.WriteLine("Reading hotel categories..");
    //await GetHotelCategories();
    //Console.WriteLine();
    //Console.WriteLine();
}

async Task GetRooms()
{
    RoomManager rep = new(helloWorld);
    var rooms = await rep.GetRoomsAsync();
    foreach (var room in rooms)
    {
        Console.WriteLine($"Room : {room}");
    }
}

//async Task<Hotel> GetHotel(int id)
//{
//    HotelManager repository = new(helloWorld);
//    return await repository.GetHotelWithIdAsync(id);
//}



//async Task GetHotelRooms(int id)
//{
//    var hotel = await GetHotel(id);
//    Console.WriteLine($"Hotel: {hotel.Name}");

//    HotelManager rep = new(helloWorld);
//    var rooms = await rep.GetHotelRoomsAsync(id);
//    foreach (var room in rooms)
//    {
//        Console.WriteLine($"    Room: {room.HotelId}");
//    }
//}

//async Task GetHotelCategories()
//{
//    HotelManager rep = new(helloWorld);
//    var categories = await rep.GetCategoriesAvailableAsync();
//    foreach (var category in categories)
//    {
//        Console.WriteLine($"categorie: {category}");
//    }
//}

//async Task GetHotelLocations()
//{
//    HotelManager rep = new(helloWorld);
//    var locations = await rep.GetLocationsAvailableAsync();
//    foreach (var location in locations)
//    {
//        Console.WriteLine($"location: {location}");
//    }
//}


//############################################################################################################
// Hotels test methods

//async Task TestHotels()
//{
//    Console.WriteLine("////////////////////");
//    Console.WriteLine("////////////////////");
//    Console.WriteLine("Reading hotels...");
//    await GetHotels();
//    Console.WriteLine();
//    Console.WriteLine();


//    Console.WriteLine("////////////////////");
//    Console.WriteLine("////////////////////");
//    Console.WriteLine("Reading hotel (byID) rooms...");
//    await GetHotelRooms(1);
//    Console.WriteLine();
//    Console.WriteLine();

//    Console.WriteLine("////////////////////");
//    Console.WriteLine("////////////////////");
//    Console.WriteLine("Reading hotel locations...");
//    await GetHotelLocations();
//    Console.WriteLine();
//    Console.WriteLine();


//    Console.WriteLine("////////////////////");
//    Console.WriteLine("////////////////////");
//    Console.WriteLine("Reading hotel categories..");
//    await GetHotelCategories();
//    Console.WriteLine();
//    Console.WriteLine();
//}

//async Task GetHotelCategories()
//{
//    HotelManager rep = new(helloWorld);
//    var categories = await rep.GetCategoriesAvailableAsync();
//    foreach (var category in categories)
//    {
//        Console.WriteLine($"categorie: {category}");
//    }
//}

//async Task GetHotelLocations()
//{
//    HotelManager rep = new(helloWorld);
//    var locations = await rep.GetLocationsAvailableAsync();
//    foreach (var location in locations)
//    {
//        Console.WriteLine($"location: {location}");
//    }
//}

//async Task GetHotels()
//{
//    HotelManager rep = new(helloWorld);
//    var hotels = await rep.GetHotelsAsync();
//    foreach (var hotel in hotels)
//    {
//        Console.WriteLine($"Hotel: {hotel.Name}");
//    }
//}

//async Task<Hotel> GetHotel(int id)
//{
//    HotelManager repository = new(helloWorld);
//    return await repository.GetHotelWithIdAsync(id);
//}



//async Task GetHotelRooms(int id)
//{
//    var hotel = await GetHotel(id);
//    Console.WriteLine($"Hotel: {hotel.Name}");

//    HotelManager rep = new(helloWorld);
//    var rooms = await rep.GetHotelRoomsAsync(id);
//    foreach (var room in rooms)
//    {
//        Console.WriteLine($"    Room: {room.HotelId}");
//    }
//}
