# mk-spike-web-ui-options-aspcore
Spike with ASP.NET core as frontend that consumes various micro services as features with seamless feature toggle and graceful degradation.

To run this you would need to follow these steps

1. Create a dir frontend and in the cmd -> git clone https://github.com/Muthuramana/mk-spike-web-ui-options-aspcore.git
2. Create a dir jpservice and in the cmd -> git clone https://github.com/Muthuramana/SitefinityMicroservice.git 
3. Create a dir skillsservice and in the cmd -> git clone https://github.com/Muthuramana/DFCSkillsMicroservice.git
4. Create a dir skillsrepo and in the cmd -> https://github.com/roysbailey/dfc.skills.data.git

5. Follow the instructions in the readme file for skillsrepo
6. cd skillsservice\DFCSkillsMicroservice\DFC.Microservices.Skills -> docker-compose -p dfcspike up -d --build
6. cd jpservice\SitefinityMicroservice\DFC.Sitefinity.MicroService.API -> docker-compose -p dfcspike up -d --build
6. cd frontend\mk-spike-web-ui-options-aspcore\Careers.Freshlook -> docker-compose -p dfcspike up -d --build

All the service should be up and running, you can access the frontend at http://localhost:5000
