using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipGameFront
{
    class BackendApi
    {
        public static async Task<ServiceData> CreateGame(CreateGame bodyData) 
        {
            ServiceData serviceData = new ServiceData(); 
            string jsonBody = System.Text.Json.JsonSerializer.Serialize(bodyData);

            ServiceResponse response = await RequestSender.Post("/game", jsonBody);

            if(response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessCreateGameResponse>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> AddPlayerTwo(AddPlayerTwo bodyData)
        {
            ServiceData serviceData = new ServiceData();
            string jsonBody = System.Text.Json.JsonSerializer.Serialize(bodyData);

            ServiceResponse response = await RequestSender.Put("/player/two", jsonBody);

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<EmptyResponse>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetPlayerId(string tableName, string playerName)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/player/index", 
                $@"?tableName={tableName}&playerName={playerName}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetPlayerByName>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetIfGameIsLocked(string tableName)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/game/is-locked", 
                $@"?tableName={tableName}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetIfGameIsLocked>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetPlayerAvailableShips(string tableName, string playerName)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/ships/all/available",
                $@"?tableName={tableName}&playerName={playerName}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetPlayerShips>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetPlayerNotAvailableShips(string tableName, string playerName)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/ships/all/not-available",
                $@"?tableName={tableName}&playerName={playerName}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetPlayerShips>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetPlayerMissedShips(string tableName, string playerName)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/ships/all/missed",
                $@"?tableName={tableName}&playerName={playerName}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetPlayerShips>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> GetPlayerTour(string gameCode)
        {
            ServiceData serviceData = new ServiceData();

            ServiceResponse response = await RequestSender.Get(
                "/player/tour",
                $@"?tableName={gameCode}"
            );

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<SuccessGetPlayerByName>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> DestroyShip(DestroyShip bodyData)
        {
            ServiceData serviceData = new ServiceData();
            string jsonBody = System.Text.Json.JsonSerializer.Serialize(bodyData);

            ServiceResponse response = await RequestSender.Put("/ships/destroy", jsonBody);

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<EmptyResponse>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }

        public static async Task<ServiceData> SetPlayerTour(SetPlayerTour bodyData)
        {
            ServiceData serviceData = new ServiceData();
            string jsonBody = System.Text.Json.JsonSerializer.Serialize(bodyData);

            ServiceResponse response = await RequestSender.Put("/player/tour", jsonBody);

            if (response.StatusCode != 200)
            {
                serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<InfoResponse>(response.ResponseJson);
                serviceData.StatusCode = response.StatusCode;
                return serviceData;
            }
            serviceData.Data = System.Text.Json.JsonSerializer.Deserialize<EmptyResponse>(response.ResponseJson);
            serviceData.StatusCode = response.StatusCode;

            return serviceData;
        }
    }
}
