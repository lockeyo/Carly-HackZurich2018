<?php
namespace App\Http\Controllers;

use Illuminate\Http\Request;

class HomeController extends Controller
{

    public function creditSuisseTest(){
        return 'Test';
    }

	public function creditSuisse(){

        $headers = array(
            'Content-type: application/json',
            'Accept: application/json',
            'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik9UUXlRVGRCTkRFNU1rWTNNMFZFTnpNeU9EWkJOa1pETkRCR1FrRkZOamxDTTBJeE5EazRNdyJ9.eyJpc3MiOiJodHRwczovL2dicHJvamVjdC5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NWI5ZDVkZDA2YTUyODY1ZGMyZTUwMmFkIiwiYXVkIjpbImh0dHBzOi8vb3BlbmJhbmtpbmcuY29tL2FwaSIsImh0dHBzOi8vZ2Jwcm9qZWN0LmF1dGgwLmNvbS91c2VyaW5mbyJdLCJpYXQiOjE1MzcwMzk4NjYsImV4cCI6MTUzNzEyNjI2NiwiYXpwIjoicThJTVlzMVNLekt0WExvdjhWM0pab3oxaE43MHgzQTciLCJzY29wZSI6Im9wZW5pZCBwcm9maWxlIGVtYWlsIiwiZ3R5IjoicGFzc3dvcmQifQ.uUxwKEiGwcRl-SiE9Iu-yLO9Th-XQH5D67VyxxwMBersCQsgZUK2mDy-C47N-_A_BVIiLtl3EsV39YXjj0-1mXL5X2BCPQPMmjHf67AFANSpz7KKpt6gkr8Lgf1yuD5j8W894DATYacA817slbtWKBqXH8aYPiLpZMYmawwaidFYBegos30VMRREbjiGVGGmNG5EfNgHH8BoFT5mT0MxeqLogJUJE3GpAllIt9QWajoiHf8GP9YeXG5KMxJWXsHHVgnFh9_N0T9KnFUbUE40uH4PwxDolJ0CW-UeXGaQiz7vA03SOe4vprhTXgp8Q8azKqQtJFHy9376enhjEsnpVQ',
        );

        // Get cURL resource
        $curl = curl_init();

        // Set some options - we are passing in a useragent too here
        curl_setopt_array($curl, array(
            CURLOPT_RETURNTRANSFER => 1,
            CURLOPT_POST => true,
            CURLOPT_URL => 'https://csopenbankingzh.azurewebsites.net/customers?nickname=marcel',
            CURLOPT_HTTPHEADER => $headers,
            CURLOPT_USERAGENT => 'Carly API Server',
            CURLOPT_POSTFIELDS => []
        ));
        // Send the request & save response to $resp
        $resp = curl_exec($curl);
        // Close request to clear up some resources
        curl_close($curl);

        // get the credit suisse data
        return  json_decode($resp)[0];
    }
}
