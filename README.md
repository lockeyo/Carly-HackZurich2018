# Carly-HackZurich2018
Carly – Introducing the car configurator of the future 

![alt text](https://menux.org/images/Carly-Logo-blau.png "Carly – Future car configurator mobile app")


## iOS - Application

We build a native iOS app and used ARKit and CoreML.

Core ML (https://developer.apple.com/documentation/coreml) is used for the image detection in combination with a cloud back-up if the detection is to slow.

ARKit (https://developer.apple.com/arkit/) is used to display the 3D car models. The car modelc can be updated in realtime.

## AMAG API

We used the AMAG API to get data from from the different vehicles, which are currently avaibale. If a user add a new vehicle we creat a new uquice ID and can than add different configurations for that car. We request the pricing for the current configurations and can thereby calculate the duration it would take to finance that specific car.

## Credit Suisse API

We created a new user on the Credit Suisse API and added a new customer. We added a KYC and can now request the banking information via the "SearchByName" endpoint. We get the usertype, which in our case is a student. We also get the anual income, anual spending, marital status, total wealth, number of kids and number of car. This data is used inside the app to calculate the money the user has to pay monthly to get the car financed. The user also see's how he does compared to his peers and what impact his financial decision has.

## Business

In the business folder you find the slide deck for the pitch presentation at Hack Zurich. We keept that really short as we think a demo is much better than just power point slides.


# Licence

Copyright 2018 Carly – HackZurich Hacker Team

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
