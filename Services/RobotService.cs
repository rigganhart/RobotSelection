using RobotSelection.Models;
using System.Text.Json;

namespace RobotSelection.Services;

public static class RobotService
{
  static readonly HttpClient client = new HttpClient();

  static List<Robot> Robots { get; set; } = new List<Robot>();
  public static async Task<List<Robot>> GetAll() {
    HttpResponseMessage response = await client.GetAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
    response.EnsureSuccessStatusCode();
    var responseBody = await response.Content.ReadAsStringAsync();
    List<Robot>? robots = JsonSerializer.Deserialize<List<Robot>>(responseBody);
    if (robots != null)
    {
      return robots;
    }
    return new List<Robot>();
  }
}