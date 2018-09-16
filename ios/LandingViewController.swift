//
//  LandingViewController.swift
//  Carly
//
//  Created by Gurinder Singh on 9/15/18.
//  Copyright © 2018 BinaryBros. All rights reserved.
//

import UIKit

class LandingViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {

    override func viewWillAppear(_ animated: Bool) {
       // navigationController?.isNavigationBarHidden = false
        navigationController?.navigationBar.prefersLargeTitles = true
    }
    override func viewDidLoad() {
        super.viewDidLoad()
        title = "Carly"
        // Do any additional setup after loading the view.
        
        //call resources
        Networking.sharedInstance.getItemsFromEndpoint1 { (success) in
            //TODO: Implement me
        }
        Networking.sharedInstance.getItemsFromEndpoint2 { (success) in
            //TODO: Implement me
        }
    }
    
    @IBAction func showMore(_ sender: Any) {
        print("tacos")
        let bookTestDriveAction = UIAlertAction(title: "Der up!",
                                                style: .default) { (action) in
                                                    // Respond to user selection of the action.
        }
        let shareAction = UIAlertAction(title: "Der e-up!",
                                        style: .default) { (action) in
                                            // Respond to user selection of the action.
        }
        let contactAction = UIAlertAction(title: "Der neue Polo",
                                          style: .default) { (action) in
                                            // Respond to user selection of the action.
        }
        let finacneAction = UIAlertAction(title: "Der Golf",
                                          style: .default) { (action) in
                                            // Respond to user selection of the action.
        }
        let cancelAction = UIAlertAction(title: "Der e-Golf",
                                         style: .default) { (action) in
                                            // Respond to user selection of the action.
        }
        let c7 = UIAlertAction(title: "Der T-Roc",
                                         style: .default) { (action) in
                                            // Respond to user selection of the action.
        }
        let c8 = UIAlertAction(title: "Der neue Golf Sportsvan",
                               style: .default) { (action) in
                                // Respond to user selection of the action.
        }
        let c9 = UIAlertAction(title: "Der Golf Variant",
                               style: .default) { (action) in
                                // Respond to user selection of the action.
        }
        let c10 = UIAlertAction(title: "Das Beetle Cabriolet",
                               style: .default) { (action) in
                                // Respond to user selection of the action.
        }
        let c11 = UIAlertAction(title: "Der Touran",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c12 = UIAlertAction(title: "Der Tiguan",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c13 = UIAlertAction(title: "Der neue Tiguan Allspace",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c14 = UIAlertAction(title: "Der Passat",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c15 = UIAlertAction(title: "Der Passat Variant",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c16 = UIAlertAction(title: "Der Arteon",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c17 = UIAlertAction(title: "Der Sharan",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c18 = UIAlertAction(title: "Der neue Touareg",
                                style: .default) { (action) in
                                    // Respond to user selection of the action.
        }
        let c19 = UIAlertAction(title: "Cancel",
                                style: .cancel) { (action) in
                                    // Respond to user selection of the action.
        }
        
        // Create and configure the alert controller.
        let alert = UIAlertController(title: nil,
                                      message: nil,
                                      preferredStyle: .actionSheet)
        alert.addAction(bookTestDriveAction)
        alert.addAction(shareAction)
        alert.addAction(contactAction)
        alert.addAction(finacneAction)
        alert.addAction(cancelAction)
        alert.addAction(c7)
        alert.addAction(c8)
        alert.addAction(c9)
        alert.addAction(c10)
        alert.addAction(c11)
        alert.addAction(c12)
        alert.addAction(c13)
        alert.addAction(c14)
        alert.addAction(c15)
        alert.addAction(c16)
        alert.addAction(c17)
        alert.addAction(c18)
        alert.addAction(c19)
        
        self.present(alert, animated: true) {
            // The alert was presented
        }
    }
    
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return 4
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "cell\(indexPath.row+1)", for: indexPath) 
        return cell
    }
    
    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 150
    }
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let row = indexPath.row
        var model:CarModel
        var modelString = ""
        switch (indexPath.row + 1) {
        case 1:
            model = .Toyota
            modelString = "Toyota"
        case 2:
            model = .Volkswagen
            modelString = "Volkswagen"
        case 3:
            model = .Lamboghini
            modelString = "Lamboghini"
        default:
            model = .Toyota
        }
        
        tableView.deselectRow(at: indexPath, animated: true)

        let vc = storyboard?.instantiateViewController(withIdentifier: "ARViewController") as! ViewController
        vc.carModel = model
        vc.carModelString = modelString
        vc.modalPresentationStyle = .overCurrentContext
        self.navigationController?.pushViewController(vc, animated: true)
        
    }
    
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
