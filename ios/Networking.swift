//
//  Networking.swift
//  Carly
//
//  Created by Gurinder Singh on 9/16/18.
//  Copyright © 2018 BinaryBros. All rights reserved.
//

import Foundation

class Networking {
    
static let sharedInstance = Networking()

let endpointURL1 = "http://94.16.116.141:5000/api/values"
let endpointURL2 = "http://94.16.116.141:5000/api/CarData/getWheelList"

//var items = [Item]()


func getItemsFromEndpoint1(completionHandler:@escaping (Bool) -> ()){
    guard let url = URL(string: endpointURL1) else { return }
    URLSession.shared.dataTask(with: url) { (data, response, error) in
        guard let data = data else { return }
        print("the response from endpoint 2 is \(response) with the data \(data)")

        do {
            let decoder = JSONDecoder()
            let loadedItems = ""//try decoder.decode([Item].self, from: data)
            //self.items = loadedItems
            
            completionHandler(true)
        } catch let err {
            print("Err", err)
            completionHandler(false)
        }
        }.resume()
    }
    
    func getItemsFromEndpoint2(completionHandler:@escaping (Bool) -> ()){
        guard let url = URL(string: endpointURL2) else { return }
        URLSession.shared.dataTask(with: url) { (data, response, error) in
            guard let data = data else { return }
            print("the response from endpoint 2 is \(response) with the data \(data)")
            do {
                let decoder = JSONDecoder()
                let loadedItems = ""//try decoder.decode([Item].self, from: data)
                //self.items = loadedItems
                
                completionHandler(true)
            } catch let err {
                print("Err", err)
                completionHandler(false)
            }
            }.resume()
    }

}
