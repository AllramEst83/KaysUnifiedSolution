
const RootAPIUrl = {
    // localhostHomeIp:'192.168.10.159:45457',
    homeIp: '192.168.43.126:45456',
    workIp: '10.231.30.139:45457'
};



class AuthorApi {
    static Guid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }


    static returnUnicorn() {
        return {
            "horntype": {
                "Id": this.Guid(),
                "type": "No Service",
                "decoration": "No Service",
                "material": "No Service"
            },
            "Id": this.Guid(),
            "name": "No Service at the moment",
            "breed": "No Service",
            "IsDeleted": false,
            "IsSold": false,
            "dateofbirth": "1000-12-12T00:00:00",
            "description": "No Service",
            "origin": "No Service"
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
            fetch(`https://${RootAPIUrl.homeIp}/api/PublicUnicorn/GetUnicorns`)
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
            fetch(`https://${RootAPIUrl.homeIp}/api/PublicUnicorn/GetAllHornTypes`)
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
            //Temp solution
            let prop = "Id";
            delete unicorn[prop];
            //Temp solution

            let data = JSON.stringify(unicorn);

            console.log(data);

            fetch(`https://${RootAPIUrl.homeIp}/api/PublicUnicorn/AddUnicorn`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': 'http://localhost:3000'
                },
                body: data
            }).then(res => res.json())
                .then(
                    (result) => {
                        resolve(Object.assign({}, result));
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
            fetch(`https://${RootAPIUrl.homeIp}/api/PublicUnicorn/UpdateUnicorn`, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': 'http://localhost:3000'
                },
                body: JSON.stringify(unicorn)
            }).then(res => res.json())
                .then(
                    (result) => {
                        resolve(Object.assign({}, result));
                        console.log(result);

                    },
                    (error) => {
                        console.log(error);
                    }
                );
        });
    }

    static DeleteUnicorn(unicorn) {
        return new Promise((resolve, reject) => {
            fetch(`https://${RootAPIUrl.homeIp}/api/PublicUnicorn/DeleteUnicorn?Id=${unicorn.Id}`, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': 'http://localhost:3000'
                }
                //body: JSON.stringify(unicornId)
            }).then(res => res.json())
                .then(
                    (result) => {
                        resolve(Object.assign({}, result));
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