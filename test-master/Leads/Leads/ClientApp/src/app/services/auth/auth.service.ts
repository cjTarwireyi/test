import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserManager, User } from 'oidc-client';
import { Constants } from '../../constants';

@Injectable()
export class AuthService {
    private _userManager: UserManager;

    constructor(private httpClient: HttpClient) {
        const config = {
            authority: Constants.stsAuthority,
            client_id: 'leadsclientid',
            redirect_uri: `${Constants.clientRoot}`,
            scope: 'openid profile',
            response_type: 'code id_token',
            post_logout_redirect_uri: `${Constants.clientRoot}`
        };
        this._userManager = new UserManager(config);
    }

    login(): Promise<any> {
        return this._userManager.signinRedirect();
    }
}
