
    const RootAPIUrl = {
        // localhostHomeIp:'192.168.10.159:45457',
        homeIp:'192.168.10.159:45457',
        localhostWorkIp:'',
        workIp:'10.231.30.139:45460'
    };

class AuthorApi {



    static returnUnicorn() {
        return {
            "HornType": {
                "Type": "Crystaline hornbug",
                "Decoration": "Very sturdy",
                "Material": "Hardened atomic Crysatline"
            },
            "Name": "Gustav",
            "Breed": "Ass whooping",
            "IsDeleted": false,
            "IsSold": false,
            "DateOfBirth": "1600-12-12T00:00:00",
            "Description": "Kicks like a mule",
            "Origin": "Azerbadjan"
        };
    }
    static returnHornType() {
        return {
            "Type": "An error occured when HornTypes was fetched",
            "Decoration": "N/A",
            "Material": "N/A"
        }
    }

    static getAllAuthors() {
        return new Promise((resolve, reject) => {
            fetch(`https://${RootAPIUrl.workIp}/api/PublicUnicorn/GetUnicorns`)
                .then(res => res.json())
                .then(
                    (result) => {
                        console.log(result.Unicorns);
                        resolve(Object.assign([], result.Unicorns));
                    },
                    // Note: it's important to handle errors here
                    // instead of a catch() block so that we don't swallow
                    // exceptions from actual bugs in components.
                    (error) => {
                        const unicorn = this.returnUnicorn();
                        console.log("error: " + error);
                        resolve(Object.assign([], [unicorn]));
                    }
                );

        });
    }

    static getAllHornTypes() {
        return new Promise((resolve, reject) => {
            fetch(`https://${RootAPIUrl.workIp}/api/PublicUnicorn/GetAllHornTypes`)
                .then(res => res.json())
                .then(
                    (result) => {
                        console.log(result.HornTypes);
                        resolve(Object.assign([], result.HornTypes));
                    },
                    // Note: it's important to handle errors here
                    // instead of a catch() block so that we don't swallow
                    // exceptions from actual bugs in components.
                    (error) => {
                        const hornType = this.returnHornType();
                        console.log("error: " + error);
                        resolve(Object.assign([], [hornType]));
                    }
                );

        });
    }

    static postUnicorn(unicorn) {
        return new Promise((resolve, reject) => {
            fetch(`https://${RootAPIUrl.workIp}/api/PublicUnicorn/AddUnicorn`, {
                method: 'post',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(unicorn)
            }).then(res => res.json())
                .then(
                    (result) => {
                        // resolve(Object.assign([], result.Unicorn));
                        console.log(result);
                    },
                    (error) => {
                        console.log(error);
                    }
                );
        });
    }

    static putUnicorn(unicorn) {
        return new Promise((resolve, reject) => {
            fetch(`https://${RootAPIUrl.workIp}/api/PublicUnicorn/UpdateUnicorn`, {
                method: 'put',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(unicorn)
            }).then(res => res.json())
                .then(
                    (result) => {
                        resolve(Object.assign([], result.Unicorn));
                        console.log(result);
                   
                    },
                    (error) => {
                        console.log(error);
                    }
                );
        });
    }

}

export default AuthorApi;