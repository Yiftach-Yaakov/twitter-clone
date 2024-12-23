import React, { useState } from "react";
import { Route, Navigate } from "react-router-dom";
import { ApplicationPaths, QueryParameterNames } from "./ApiAuthorizationConstants";
import authService from "./AuthorizeService";

const AuthorizeRoute: React.FC<any> = (props, ) => {
	const [state, setState] = useState({
		ready: false,
		authenticated: false,
	});

	const populateAuthenticationState = async () => {
		const authenticated = await authService.isAuthenticated();
		setState((state) => ({ ...state, ready: true, authenticated: authenticated }));
	};

	const authenticationChanged = async () => {
		setState({ ready: false, authenticated: false });
		await populateAuthenticationState();
	};

	React.useEffect(() => {
		// const subscription = authService.subscribe(() => authenticationChanged());
		populateAuthenticationState();
		return () => {
			// authService.unsubscribe(subscription);
		};
	}, []);

	const { ready, authenticated } = state;

	var link = document.createElement("a");
	link.href = props.path;

	const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
	const redirectUrl = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURIComponent(returnUrl)}`;
	if (!ready) {
		return <div></div>;
	} else {
		//return <React.Fragment>{props.children}</React.Fragment>;
		return authenticated ?  <>{props.children} </> : <Navigate to={redirectUrl}/>;
	}
};

export default AuthorizeRoute;
